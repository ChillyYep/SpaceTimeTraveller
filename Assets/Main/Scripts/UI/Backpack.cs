using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour {
    public GameObject propItemPrefab;//道具项预制体
    public GameObject listContent;//道具列表
    public GameObject nameArea;//道具名
    public GameObject propImage;//道具图
    public GameObject descriptionArea;//描述区域

    public static Backpack instance = null;
    private Dictionary<string, GameObject> propItemsDictionary = new Dictionary<string, GameObject>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        UpdateBackpack();
    }

    void Update()
    {
        if (GetComponent<Canvas>().worldCamera != Camera.main)
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }
    //加载道具列表
    private void UpdateBackpack()
    {
        if (BackPackManager.instance != null)
        {
            
            foreach(Prop prop in BackPackManager.instance.currentPropsDictionary.Values)
            {
                AddProp(prop);
            }
        }
    }

    //添加道具
    public void AddProp(Prop prop)
    {
        GameObject item = null;
        if (propItemPrefab != null)
        {
            item = Instantiate(propItemPrefab, listContent.transform);
            item.GetComponent<Button>().onClick.AddListener(()=>
            {
                ShowPropInfo(prop);
            });
            item.GetComponent<PropInfo>().prop = prop;
            if(prop.spriteIndex < BackPackManager.instance.sprites.Count)
            {
                item.GetComponent<Image>().sprite = BackPackManager.instance.sprites[prop.spriteIndex];
            }
            propItemsDictionary.Add(prop.name, item);
        }
    }

    //删除道具
    public void RemoveProp(string propName)
    {
        GameObject item = null;
        if ((item = propItemsDictionary[propName]) != null)
        {
            propItemsDictionary.Remove(propName);
            Destroy(item);
        }
    }
    //点击显示道具信息
    public void ShowPropInfo(Prop prop)
    {
        //Debug.Log("ShowPropInfo.name" + prop.name);
        //Debug.Log("ShowPropInfo.spriteIndex" + prop.spriteIndex);
        //Debug.Log("ShowPropInfo.description" + prop.description);
        nameArea.GetComponent<Text>().text = prop.name;
        if (prop.spriteIndex < BackPackManager.instance.sprites.Count)
        {
            propImage.GetComponent<Image>().sprite = BackPackManager.instance.sprites[prop.spriteIndex];
            propImage.GetComponent<Image>().color = Color.white;
        }
        descriptionArea.GetComponent<Text>().text = prop.description;
        descriptionArea.transform.parent.GetComponent<Image>().color = Color.gray;


    }
}
