using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject settingPanel;
    public GameObject backpackPrefab;

    public static UIController instance = null;

    private Canvas canvas;
    private GameObject backpack;
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
        //DontDestroyOnLoad(gameObject);

        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == GlobalManager.SceneCode.MainUI && instance != null)
        {
            Destroy(gameObject);
        }
        if (canvas.worldCamera != Camera.main)
        {
            canvas.worldCamera = Camera.main;
            //canvas.sortingLayerName = GloabalManager.LayerNameManager.BackgroundLayer;
            //canvas.sortingOrder = -1;
        }
    }

    public void gotoSetting()
    {
        if (SettingPanel.instance == null)
        {
            Instantiate(settingPanel);
        }
        SettingPanel.instance.GetComponent<Canvas>().worldCamera = Camera.main;
        SettingPanel.instance.ShowSettingPanel();
    }

    public void GotoMainUI()
    {
        GlobalManager.SceneCode.ChangeScene(GlobalManager.SceneCode.MainUI);
        //UnityEngine.SceneManagement.SceneManager.LoadScene(GloabalManager.SceneCodeManager.MainUI);
    }

    //呼出背包界面
    public void CallBackpack()
    {
        if (BackPackManager.instance != null)
        {
            BackPackManager.instance.CallBackpack();
        }
    }
}
