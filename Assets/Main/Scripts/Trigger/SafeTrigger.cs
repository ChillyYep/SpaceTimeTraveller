using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeTrigger : MonoBehaviour
{
    public GameObject safeCanvas;

    [HideInInspector]
    public bool allowKeyDown = false;
    public static SafeTrigger instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (allowKeyDown)
        {
            if (TipsManager.instance != null)
            {
                TipsManager.instance.FlyIn(GlobalManager.Tips.IntoOther);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (allowKeyDown)
            {
                CharacterController.instance.moveable = false;//玩家不能移动
                safeCanvas.GetComponent<SafeCanvasManager>().Open();//开启画布
                allowKeyDown = false;
            }
            else
            {
                if (TipsManager.instance != null)
                {
                    TipsManager.instance.FlyIn(GlobalManager.Tips.DontTouchProp);
                }
            }
        }
    }
}
