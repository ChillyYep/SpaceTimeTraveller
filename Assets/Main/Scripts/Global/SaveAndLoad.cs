using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//用于保存或加载数据
public class SaveAndLoad : MonoBehaviour {
    public static SaveAndLoad instance = null;//单件模式，SaveAndLoad的唯一索引
    private string sceneName = null;
    private string sceneCode = null;
<<<<<<< HEAD
=======
    [HideInInspector]
>>>>>>> new
    public List<string> propNames = null;


    private ReadWriteArchive.Archive _currentArchive;
    public ReadWriteArchive.Archive currentArchive
    {
        get
        {
            return _currentArchive;
        }
    }
    //public ReadWriteArchive.Archive
    void Awake()
    {
        if (instance == null)
        {
            instance = this;//指定唯一对象
        }
        else if (instance != this)
        {
            Destroy(gameObject);//不允许生成第二个该对象
        }
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		if(sceneCode!=null&& SceneManager.GetActiveScene().name != sceneCode)
        {
            sceneCode = SceneManager.GetActiveScene().name;
        }
    }

    //修改当前存档的信息，但不保存
    public void SetCurrentArchive(string sceneName, string sceneCode, List<string> propNames)
    {
        _currentArchive.sceneName = sceneName;
        _currentArchive.sceneCode = sceneCode;
        _currentArchive.propNames = propNames;
    }

    public void ResetCurrentaArchive()
    {
        _currentArchive.sceneName = sceneName;
        _currentArchive.sceneCode = sceneCode;
        _currentArchive.propNames = propNames;
    }

    //读档
    public void LoadArchive(string filename)
    {
        ReadWriteArchive readWriteArchive = ReadWriteArchive.GetInstance();
        _currentArchive = readWriteArchive.LoadArchive(filename);
        //Debug.Log("Is CurrentArchive NULL:" + (_currentArchive == null));
        sceneName = _currentArchive.sceneName;
        sceneCode = _currentArchive.sceneCode;
        //Debug.Log("sceneCode:" + sceneCode);
        propNames = new List<string>(_currentArchive.propNames);
        //propNames = _currentArchive.propNames;
<<<<<<< HEAD
        GloabalManager.SceneCodeManager.ChangeScene(sceneCode);
=======
        GlobalManager.SceneCode.ChangeScene(sceneCode);
>>>>>>> new
    }
    //存档
    public void SaveArchive()
    {
        //ReadWriteArchive.GetInstance().CreateArchive();
        ReadWriteArchive.GetInstance().SaveArchive(_currentArchive);
                sceneName = _currentArchive.sceneName;
        sceneCode = _currentArchive.sceneCode;
        //Debug.Log("sceneCode:" + sceneCode);
        propNames = new List<string>(_currentArchive.propNames);
        //CreateArchiveElements.isUpdate = true;//暂时没用
    }
    //创建存档
    public void CreateArchive()
    {
        _currentArchive = ReadWriteArchive.GetInstance().CreateArchive();
        //CreateArchiveElements.isUpdate = true;//暂时没用
    }

    public void DeleteArchive(string filename)
    {
        ReadWriteArchive.GetInstance().DeleteArchive(filename);
    }


    //获取当前存档中的场景名
    public string GetCurrentSceneName()
    {
        if (_currentArchive != null)
            return _currentArchive.sceneName;
        return null;
    }

    //获取当前存档中的场景代号
    public string GetCurrentSceneCode()
    {
        if (_currentArchive != null)
            return _currentArchive.sceneCode;
        return null;
    }

    //获取当前存档中的道具列表
    public List<string> GetCurrentPropNames()
    {
        if (_currentArchive != null)
            return _currentArchive.propNames;
        return null;
    }
}
