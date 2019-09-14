using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class BackPackManager : MonoBehaviour {
    public List<Sprite> sprites;
    public GameObject backpackPrefab;
    //public GameObject backpackPrefab;

    public static BackPackManager instance = null;
    public Dictionary<string, Prop> currentPropsDictionary=new Dictionary<string, Prop>();//当前拥有道具的字典
    private Dictionary<string, Prop> allPropsDictionary = new Dictionary<string, Prop>();//所有道具的字典

    private GameObject backpack;
    //private GameObject backpack;

    [Serializable]
    struct PropList
    {
        public List<Prop> props;
    }

    void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        LoadProps();
    }
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == GlobalManager.SceneCode.MainUI)
        {
            instance = null;
            DestroyImmediate(backpack);
            DestroyImmediate(gameObject);
        }
    }
    //添加到当前道具字典
    public void AddProp(string propName)
    {
        currentPropsDictionary.Add(propName, allPropsDictionary[propName]);
        if (TipsManager.instance != null)
        {
            TipsManager.instance.FlyIn(String.Format(GlobalManager.Tips.GetSomeProp1, propName));
        }
        if (Backpack.instance != null)//添加到背包
        {
            Backpack.instance.AddProp(currentPropsDictionary[propName]);
        }
        Debug.Log("addprop" + propName);
    }

    public void AddProp(List<string> propNameList)
    {
        //string propNames = "";
        foreach(string propName in propNameList)
        {
            currentPropsDictionary.Add(propName, allPropsDictionary[propName]);
            if (Backpack.instance != null)//添加到背包
            {
                Backpack.instance.AddProp(currentPropsDictionary[propName]);
            }
            //propNames += propName;
            Debug.Log("addprop" + propName);
        }
        if (TipsManager.instance != null)
        {
            switch (propNameList.Count)
            {
                case 1:
                    TipsManager.instance.FlyIn(String.Format(GlobalManager.Tips.GetSomeProp1, propNameList[0]));
                    break;
                case 2:
                    TipsManager.instance.FlyIn(String.Format(GlobalManager.Tips.GetSomeProp2, propNameList[0], propNameList[1]));
                    break;
                default:
                    break;
            }
        }
    }
    public void RemoveProp(string propName)
    {
        currentPropsDictionary.Remove(propName);
        if (TipsManager.instance != null)
        {
            TipsManager.instance.FlyIn(String.Format(GlobalManager.Tips.LoseSomeProp, propName));
        }
        if (Backpack.instance != null)//添加到背包
        {
            Backpack.instance.RemoveProp(propName);
        }
    }
    //呼出背包界面
    public void CallBackpack()
    {
        if (backpack == null)//生成背包
        {
            backpack = Instantiate(backpackPrefab);
            backpack.GetComponent<Canvas>().worldCamera = Camera.main;
        }
        else//展现层
        {
            backpack.GetComponent<Canvas>().sortingLayerName = GlobalManager.LayerName.UILayer;
            backpack.GetComponent<Canvas>().sortingOrder = 1;
        }
    }
    public List<string> GetPropNames()
    {
        List<string> propNames = new List<string>(currentPropsDictionary.Keys);
        foreach(string propName in propNames)
        {
            Debug.Log("GetPropNames:" + propName);
        }
        return propNames;
    }
    //加载已拥有的Prop到propsDictionary中
    private void LoadProps()
    {
        if (SaveAndLoad.instance != null)
        {
            List<string> propNames = SaveAndLoad.instance.propNames;

            allPropsDictionary = LoadAllPropsInfo();//所有道具
            if (propNames != null)
            {
                foreach (string propName in propNames)
                {
                    currentPropsDictionary.Add(propName, allPropsDictionary[propName]);//自己所拥有的道具
                }
            }
        }
    }
    //所有道具的字典
    private Dictionary<string, Prop> LoadAllPropsInfo()
    {
        Dictionary<string, Prop> keyValuePairs = new Dictionary<string, Prop>();
        FileStream fileStream = null;
        StreamReader sr = null;
        try
        {
            try
            {
                fileStream = new FileStream(GlobalManager.PathName.PropsPath, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return null;
            }
            sr = new StreamReader(fileStream,Encoding.Default);
        }
        catch
        {
            return null;
        }

        string propsListJson = sr.ReadToEnd();
        Debug.Log("propsListJson:" + propsListJson);
        PropList propList = JsonUtility.FromJson<PropList>(propsListJson);
        Debug.Log("propList.props.Count:" + propList.props.Count); 

        foreach (Prop prop in propList.props)
        {
            keyValuePairs.Add(prop.name, prop);
            Debug.Log("prop.name:" + prop.name);
        }
        sr.Close();
        fileStream.Close();
        return keyValuePairs;
    }
}
