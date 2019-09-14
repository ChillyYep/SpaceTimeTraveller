using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swicth : MonoBehaviour {
    public GameObject wardobe;
    public GameObject Fria;
    public GameObject Ady;
    public GameObject dialogTrigger1;//AdyTalk Trigger
    public GameObject dialogTrigger2;//
    public GameObject letterAndPicturePrefabs;
    public GameObject envelope;
    public DoorTrigger dinningHallDoorTrigger;
    public GameObject selectBox;

    public GameObject HappyEndBackToMenuUI;
    public GameObject BadEndBackToMenuUI;


    public static Swicth instance = null;

    private Animator currentAnimator;
    private string animationName;
    private bool isPlay = false;
    private GameObject letterAndPicture = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isPlay)
        {
            if (!CharacterController.instance.moveable)
            {
                AnimatorStateInfo animatorStateInfo = currentAnimator.GetCurrentAnimatorStateInfo(0);
                if (animatorStateInfo.IsName(animationName) && animatorStateInfo.normalizedTime >= 1.0f)
                {
                    CharacterController.instance.moveable = true;
                    isPlay = false;
                }
            }
        }
    }

    private void FriaSwicthOn()
    {
        if (Fria != null && wardobe != null)
        {
            isPlay = true;
            CharacterController.instance.moveable = false;
            CharacterController.instance.StopWalkAnim();
            wardobe.GetComponent<Animator>().Play("OpenWardobe");
            Fria.SetActive(true);
            currentAnimator = Fria.GetComponent<Animator>();
            animationName = "FriaWalk";
            currentAnimator.Play(animationName);
        }
    }

    private void AdyTalk1()
    {
        //DialogManager.instance.AddUnRepeatableDialog(GloabalManager.StoryFileName.FriaBedroom3);
        if (dialogTrigger1 != null)
        {
            dialogTrigger1.GetComponent<DialogTrigger>().canTrigger = true;
        }
    }

    private void AfterTakeEnvelope()
    {
        if (letterAndPicturePrefabs != null)
        {
            CharacterController.instance.moveable = false;
            letterAndPicture = Instantiate(letterAndPicturePrefabs);
            letterAndPicture.GetComponent<Canvas>().worldCamera = Camera.main;
            letterAndPicture.transform.Find("Background").Find("BackBtn").GetComponent<Button>().onClick.AddListener(() => {
                DestroyImmediate(letterAndPicture);
                GalleryOutdoorTalk2();
            });
        }
        if (envelope != null)
        {
            envelope.GetComponent<AddProp>().Do();
            //string prop1Name = "信件";
            //string prop2Name = "雨街";
            //addProp.propNames.Add(prop1Name);
            //addProp.propNames.Add(prop2Name)
        }
    }

    private void AdySwitchOn()
    {
        if (Ady != null)
        {
            isPlay = true;
            CharacterController.instance.moveable = false;
            CharacterController.instance.StopWalkAnim();
            Ady.SetActive(true);
            //Ady.GetComponent<Animator>().SetBool("Walk", true);
            currentAnimator = Ady.GetComponent<Animator>();
            animationName = "AdyWalk";
            currentAnimator.Play(animationName);
        }
    }

    private void GalleryOutdoorTalk2()
    {
        if (DialogManager.instance != null)
        {
            DialogManager.instance.AddUnRepeatableDialog(GlobalManager.StoryFileName.GalleryOutdoor2);
        }
    }
    private void AdySwichOff()
    {
        Ady.GetComponent<Animator>().SetBool("Walk", false);
    }

    private void travelSwitchOn()
    {
        GlobalManager.SceneCode.ChangeScene(GlobalManager.SceneCode.SecondChapter);
    }

    private void HappyEnd()
    {
        CharacterController.instance.moveable = false;
        if (HappyEndBackToMenuUI != null)
        {
            GameObject temp = Instantiate(HappyEndBackToMenuUI) as GameObject;
            temp.transform.Find("HappyEndImage").Find("BackBtn").GetComponent<Button>().onClick.AddListener(() => { ToMenuUI(); });
            temp.GetComponent<Canvas>().worldCamera = Camera.main;
        }
        //StartCoroutine(ToMenuUI());
    }

    public void BadEnd()
    {
        CharacterController.instance.moveable = false;
        if (BadEndBackToMenuUI != null)
        {
            GameObject temp = Instantiate(BadEndBackToMenuUI) as GameObject;
            temp.transform.Find("BadEndImage").Find("BackBtn").GetComponent<Button>().onClick.AddListener(() => { ToMenuUI(); });
            temp.GetComponent<Canvas>().worldCamera = Camera.main;
        }
        //StartCoroutine(ToMenuUI());
    }

    private void Choose()
    {
        if (selectBox != null)
        {
            GameObject select = Instantiate(selectBox) as GameObject;
            select.GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }

    //控制逻辑
    public void SwicthByDialogFileName(string storyFileName)
    {
        switch (storyFileName)
        {
            case GlobalManager.StoryFileName.CastleIndoor1:
                break;
            case GlobalManager.StoryFileName.CastleIndoor2:
                SafeTrigger.instance.allowKeyDown = true;
                break;
            case GlobalManager.StoryFileName.CastleOutdoor1:
                break;
            case GlobalManager.StoryFileName.CastleOutdoor2:
                break;
            case GlobalManager.StoryFileName.FriaBedroom1:
                FriaSwicthOn();
                break;
            case GlobalManager.StoryFileName.FriaBedroom2:
                if (dinningHallDoorTrigger != null)
                {
                    dinningHallDoorTrigger.enableEnter = true;
                }
                break;
            case GlobalManager.StoryFileName.FriaBedroomFound://给苹果之后的对话结束时调用
                AdyTalk1();
                break;
            case GlobalManager.StoryFileName.FriaBedroom3://开启Ady动画
                AdySwitchOn();
                break;
            case GlobalManager.StoryFileName.FriaBedroom4:
                travelSwitchOn();
                break;
            case GlobalManager.StoryFileName.FriaBedroomNoFound:
                break;
            case GlobalManager.StoryFileName.GalleryOutdoor1:
                AfterTakeEnvelope();
                break;
            case GlobalManager.StoryFileName.Studio1:
                if (CameraMoveAnimController.instance != null)
                {
                    CameraMoveAnimController.instance.UnBind();
                }
                break;
            case GlobalManager.StoryFileName.TalkToAyr1:
                break;
            case GlobalManager.StoryFileName.TalkToAyr2:
                SafeTrigger.instance.allowKeyDown = true;
                break;
            case GlobalManager.StoryFileName.TalkToAyr3:
                //
                break;
            case GlobalManager.StoryFileName.TalkToAyr4:
                Choose();
                break;
            case GlobalManager.StoryFileName.TalkToSuJin:
                HappyEnd();
                break;
            default:
                break;
        }
    }

    void ToMenuUI()
    {
        //yield return new WaitForSeconds(2.0f);
        //UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(GloabalManager.SceneCodeManager.MainUI);
        GlobalManager.SceneCode.ChangeScene(GlobalManager.SceneCode.MainUI);
    }

}
