using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveAnimController : MonoBehaviour
{
    private bool hasTrigger = false;
    private bool isBind = false;
    public static CameraMoveAnimController instance = null;

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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTrigger)
        {
            if (CameraController.instance != null)
            {
                StartCoroutine(Exclam());
                hasTrigger = true;
            }
        }
    }

    IEnumerator Exclam()
    {
        CharacterController.instance.moveable = false;//停止移动
        CharacterController.instance.StopWalkAnim();

        CharacterController.instance.ShowExclam();
        yield return new WaitForSeconds(1.0f);
        CharacterController.instance.HideExclam();
        yield return new WaitForEndOfFrame();
        Bind();
        CameraController.instance.AutoMove2RightAnim();
        //CameraController.instance.afterCameraMove -= AddDialog;
    }
    void Bind()
    {
        isBind = true;
        CameraController.instance._afterCameraMove += AddDialog;
    }

    
    void AddDialog()
    {
<<<<<<< HEAD
        DialogManager.instance.AddUnRepeatableDialog(GloabalManager.StoryFileName.Studio1);
=======
        DialogManager.instance.AddUnRepeatableDialog(GlobalManager.StoryFileName.Studio1);
>>>>>>> new

    }

    public void UnBind()
    {
        if (isBind)
        {
            CameraController.instance._afterCameraMove -= AddDialog;
        }
    }
}
