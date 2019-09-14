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
        GlobalManager.SceneCode.ChangeScene(name);
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
        aboutUsPanelInstance.GetComponent<Canvas>().sortingLayerName = GlobalManager.LayerName.UILayer;
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
        loadArchivePanelInstance.GetComponent<Canvas>().sortingLayerName = GlobalManager.LayerName.UILayer;
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
