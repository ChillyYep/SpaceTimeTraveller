using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    //public string sceneName;
    //public Vector3 characterPos = Vector3.zero;
    public GameObject posPoint;
    public GameObject character;
    public GameObject canvasArea;
    public bool enableEnter = true;
    public string forbiddenTips = "";
    //public GameObject character;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (enableEnter)
        {
            ShowTip();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Press Space!");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Press Space!");
            if (enableEnter)
            {
                if(posPoint!=null&& character!=null&& canvasArea != null)
                {
                    CameraController.instance.canvasArea = canvasArea;
                    CameraController.instance.UpdateCriticalPoint();
                    //character.transform.position = characterPos;
                    character.transform.position = posPoint.transform.position;
                }
                if (SoundController.instance != null)
                {
                    SoundController.instance.PlaySoundEffect(SoundController.SoundEffect.DOOR);
                }
            }
            else
            {
                if (TipsManager.instance != null)
                {
                    if (forbiddenTips == "")
                    {
                        TipsManager.instance.FlyIn(GlobalManager.Tips.DoorIsClose);
                    }
                    else
                    {
                        TipsManager.instance.FlyIn(forbiddenTips);
                    }
                }
            }
        }
    }

    public void ShowTip()
    {
        if (TipsManager.instance != null)
        {
            TipsManager.instance.FlyIn(GlobalManager.Tips.SpaceToEnterTip);
        }
    }
}
