using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnController : MonoBehaviour {
    public GameObject settingPanel;
    public GameObject aboutUsPanel;
    public GameObject loadArchivePanel;

    private GameObject aboutUsPanelInstance = null;
    private GameObject loadArchivePanelInstance = null;

    public void NewGame(string name)
    {
<<<<<<< HEAD
        GloabalManager.SceneCodeManager.ChangeScene(name);
=======
        GlobalManager.SceneCode.ChangeScene(name);
>>>>>>> new
        if (SaveAndLoad.instance != null)
        {
            SaveAndLoad.instance.CreateArchive();
        }
    }

    public void gotoAboutUs()
    {
        if (aboutUsPanelInstance == null)
        {
            aboutUsPanelInstance = Instantiate(aboutUsPanel);
        }
        aboutUsPanelInstance.GetComponent<Canvas>().worldCamera = Camera.main;
<<<<<<< HEAD
        aboutUsPanelInstance.GetComponent<Canvas>().sortingLayerName = GloabalManager.LayerNameManager.UILayer;
=======
        aboutUsPanelInstance.GetComponent<Canvas>().sortingLayerName = GlobalManager.LayerName.UILayer;
>>>>>>> new
        aboutUsPanelInstance.GetComponent<Canvas>().sortingOrder = 3;
    }

    public void gotoLoadArchive()
    {
        if (loadArchivePanelInstance == null)
        {
            loadArchivePanelInstance = Instantiate(loadArchivePanel);
        }
        else if (CreateArchiveElements.instance != null)
        {
            CreateArchiveElements.instance.UpdateArchivesPanel();
        }
        
        loadArchivePanelInstance.GetComponent<Canvas>().worldCamera = Camera.main;
<<<<<<< HEAD
        loadArchivePanelInstance.GetComponent<Canvas>().sortingLayerName = GloabalManager.LayerNameManager.UILayer;
=======
        loadArchivePanelInstance.GetComponent<Canvas>().sortingLayerName = GlobalManager.LayerName.UILayer;
>>>>>>> new
        loadArchivePanelInstance.GetComponent<Canvas>().sortingOrder = 3;
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

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    //public void saveSetting()
    //{
    //    //做一些设置保存
    //    gotoOtherPanel(mainMenu);
    //}

    //void OnDestroy()
    //{
    //    settingCanvas.sortingLayerName = "Background";
    //    settingCanvas.sortingOrder = -1;
    //}
}
