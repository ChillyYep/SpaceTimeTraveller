using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour {
    public static SettingPanel instance = null;

    private Slider musicVolumnSlider;
    private AudioSource music;
    private Canvas canvas;
    // Use this for initialization
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
        canvas = GetComponent<Canvas>();
        musicVolumnSlider = transform.GetChild(0).Find("MusicVolumnSlider").GetComponent<Slider>();
    }

    void Start () {
        music = SoundController.instance.music;
        musicVolumnSlider.value = music.volume;
        Debug.Log("musicVolumn:" + musicVolumnSlider.value);
    }
	
	// Update is called once per frame
	void Update () {
        if (canvas.worldCamera != Camera.main)
        {
            canvas.worldCamera = Camera.main;
<<<<<<< HEAD
            canvas.sortingLayerName = GloabalManager.LayerNameManager.BackgroundLayer;
=======
            canvas.sortingLayerName = GlobalManager.LayerName.BackgroundLayer;
>>>>>>> new
            canvas.sortingOrder = -1;
        }
    }

    public void ChangeVolumn()
    {
        music.volume = musicVolumnSlider.value;
    }
    public void SaveSetting()
    {
        //保存音量
        SaveVolumn();
        //ReadWriteSetting.GetInstance().WriteSetting();
    }
    private void SaveVolumn()
    {
        ReadWriteSetting readWriteSetting = ReadWriteSetting.GetInstance();
        readWriteSetting.GetSetting().musicVolumn = music.volume;
        Debug.Log("musicVolumn:" + music.volume);

        readWriteSetting.WriteSetting();
    }
    public void ShowSettingPanel()
    {
        Canvas canvas = GetComponent<Canvas>();
<<<<<<< HEAD
        canvas.sortingLayerName = GloabalManager.LayerNameManager.UILayer;
=======
        canvas.sortingLayerName = GlobalManager.LayerName.UILayer;
>>>>>>> new
        canvas.sortingOrder = 3;
    }
}
