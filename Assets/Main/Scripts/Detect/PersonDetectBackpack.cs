using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonDetectBackpack : DetectBackpack
{
    public string noFoundFileName;
    public string foundFileName;

    private bool allowKeyDown = true;
    private bool allowCommunicate = true;

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
        if (allowCommunicate)
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
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (allowCommunicate)
        {
            if (allowKeyDown&&Input.GetKeyDown(KeyCode.X))//允许按键且按下X后的操作
            {
                if (IsExistInBackpack())
                {
                    //推进剧情
                    if (DialogManager.instance != null)
                    {
                        DialogManager.instance.AddUnRepeatableDialog(foundFileName);
                        BackPackManager.instance.RemoveProp(propName);
                    }
                    allowCommunicate = false;
                }
                else
                {
                    //催促找食物
                    if (DialogManager.instance != null)
                    {
                        DialogManager.instance.AddRepeatableDialog(noFoundFileName);
                    }
                }
                allowKeyDown = false;
            }
        }
    }
}
