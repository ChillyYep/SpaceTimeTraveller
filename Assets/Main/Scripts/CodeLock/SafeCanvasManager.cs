using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCanvasManager : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(false);
        CharacterController.instance.moveable = true;//玩家可以移动
        if (SafeTrigger.instance != null)
        {
            SafeTrigger.instance.allowKeyDown = true;
        }

    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
}
