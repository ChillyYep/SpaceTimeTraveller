using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToNPC : DetectBackpack
{
    public List<string> dialogFileNameList = new List<string>();
    //public GameObject selectBox;
    //public string dialogFileName;
    private bool allowKeyDown = true;
    [HideInInspector]
    public int currentDialogIndex = 0;

    void Update()
    {
        if (!allowKeyDown)
        {
            if (DialogManager.instance.isDialogOver)//对话结束，允许按键
            {
                allowKeyDown = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (TipsManager.instance != null)//提示
        {
<<<<<<< HEAD
            TipsManager.instance.FlyIn(GloabalManager.Tips.TalkToSomeone);
=======
            TipsManager.instance.FlyIn(GlobalManager.Tips.TalkToSomeone);
>>>>>>> new
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (allowKeyDown && Input.GetKeyDown(KeyCode.X))//对话
        {
            if (DialogManager.instance != null)
            {
                if (!JudgIfRepeatable(dialogFileNameList[currentDialogIndex]))
                {
                    DialogManager.instance.AddUnRepeatableDialog(dialogFileNameList[currentDialogIndex]);
                    NextDialog();
                }
                else
                {
                    DialogManager.instance.AddRepeatableDialog(dialogFileNameList[currentDialogIndex]);
                }
                allowKeyDown = false;
            }
        }
    }
    
    public void NextDialog()
    {
        if (currentDialogIndex < dialogFileNameList.Count)
        {
            currentDialogIndex++;
        }
    }

    //private void Choose()
    //{
    //    GameObject select = Instantiate(selectBox) as GameObject;
    //    select.GetComponent<Canvas>().worldCamera = Camera.main;
    //}

    private bool JudgIfRepeatable(string storyFileName)
    {
        switch (storyFileName)
        {
<<<<<<< HEAD
            case GloabalManager.StoryFileName.TalkToAyr3:
=======
            case GlobalManager.StoryFileName.TalkToAyr3:
>>>>>>> new
                if (IsExistInBackpack())
                {
                    NextDialog();
                    return false;
                }
                return true;
            //case GloabalManager.StoryFileName.TalkToAyr4:
            //    Choose();
                //break;
            default:
                break;
        }
        return false;
    }
}
