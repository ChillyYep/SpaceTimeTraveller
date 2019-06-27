using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInOut : MonoBehaviour {
    public string filename;

    public static bool isPlayTextFadeInOut=false;
    public static bool isPlayOtherAnim = false;

    private Animator animator;
    private Text text;
    //private string[] storyScripts2 = { "我", "很希望", "能再见你一面" };
    private List<string> storyScripts;
    private int index = 0;
    private readonly Color startColor = new Color(1f, 1f, 1f, 0f);
    private bool into = true;
    private AnimatorStateInfo animatorStateInfo;
    // Use this for initialization
    void Start () {
        //storyScripts = new List<string>(storyScripts2);
        Debug.Log("Application.dataPath:" + Application.dataPath);
<<<<<<< HEAD
        storyScripts = ReadStory.GetStoryReader().readFile(GloabalManager.PathNameManager.MonologuePath+filename);
=======
        storyScripts = ReadStory.GetStoryReader().readFile(GlobalManager.PathName.MonologuePath+filename);
>>>>>>> new
        if (storyScripts.Count == 0)
        {
            storyScripts.Add("");
        }
        animator = gameObject.GetComponent<Animator>();
        animator.speed = 0.0f;
        text = gameObject.GetComponent<Text>();
        text.color = startColor;
    }
	
	// Update is called once per frame
	void Update () {
        if (isPlayTextFadeInOut && into)
        {
            text.text = storyScripts[index];
            animator.speed = 1.0f;
            into = false;
        }
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName("FadeOut") && animatorStateInfo.normalizedTime >= 1.0f && index <= storyScripts.Count-1)
        {
            FadeIn(storyScripts[index]);
        }
    }

    private void FadeIn(string storyScript)
    {
        text.text = storyScript;
        animator.SetBool("Into", true);
    }

    public void Next(string sceneCode="")
    {
        if(index< storyScripts.Count-1)
        {
            FadeOut(storyScripts[index++]);
        }
        else
        {
            //gameObject.SetActive(false);
            //isPlayTextFadeInOut = false;
            isPlayOtherAnim = true;
            if (sceneCode != "")
            {
<<<<<<< HEAD
                GloabalManager.SceneCodeManager.ChangeScene(sceneCode);
=======
                GlobalManager.SceneCode.ChangeScene(sceneCode);
>>>>>>> new
            }
        }
    }
    public void Ding()
    {
        if (SoundController.instance != null)
        {
            SoundController.instance.PlaySoundEffect(SoundController.SoundEffect.DIALOG);
        }
    }
    private void FadeOut(string storyScript)
    {
        animator.SetBool("Into", false);
    }

    //void OnGUI()
	   //{
	   // //用新的皮肤资源，显示中文
	   //     GUI.skin = skin;
	   //     //读取文件中的所有内容
	   //     foreach(string str in infoall)
	   //     {
	   //         //绘制在屏幕当中，哇咔咔！
	   //         GUILayout.Label(str);
	   // }
}
