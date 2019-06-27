using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public Transform cameraDestination;
    public Transform mainCharacterDestination;
    public GameObject mainCharacter;
    public GameObject _camera;

    private bool hasTrigger = false;
    private const float MoveCameraTime = 3.0f;
    private const float MoveCharacterTime = 3.0f;
    private const int frameCountPerSecond = 25;
    void Awake()
    {
        //_camera = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTrigger)
        {
            StartCoroutine(PlayAnim());
        }
    }

    IEnumerator PlayAnim()
    {
        float deltaCharacterX = mainCharacterDestination.localPosition.x - mainCharacter.transform.localPosition.x;//人物移动的距离
        float deltaCameraX = cameraDestination.localPosition.x - _camera.transform.localPosition.x;//摄像机移动的距离
        int frameCount1 = (int)(frameCountPerSecond * MoveCameraTime);//相机移动帧数
        int frameCount2 = (int)(frameCountPerSecond * MoveCharacterTime);//人物移动帧数

        CharacterController characterController = mainCharacter.GetComponent<CharacterController>();
        _camera.GetComponent<CameraController>().pauseControllCamera = true;//回收摄像机的控制权
        characterController.moveable = false;//回收人物的控制权

        characterController.ShowExclam();//惊叹
        characterController.StopWalkAnim();
        yield return new WaitForSeconds(1);
        characterController.HideExclam();//惊叹

        for (int i=0;i< frameCount1; i++)
        {
            yield return new WaitForSeconds(1 / frameCountPerSecond);
            _camera.transform.localPosition += new Vector3(deltaCameraX / frameCount1, 0, 0);
        }
        characterController.StartWalkAnim();//开启人物走动动画
        for(int i = 0; i < frameCount2; i++)
        {
            yield return new WaitForSeconds(1 / frameCountPerSecond);
            mainCharacter.transform.position += new Vector3(deltaCharacterX / frameCount2, 0, 0);
        }
        characterController.StopWalkAnim();//开启人物走动动画
        //_camera.GetComponent<CameraController>().pauseControllCamera = false;
        //mainCharacter.GetComponent<CharacterController>().moveable = true;
        if (DialogManager.instance != null)
        {
<<<<<<< HEAD
            DialogManager.instance.AddUnRepeatableDialog(GloabalManager.StoryFileName.TalkToSuJin);
=======
            DialogManager.instance.AddUnRepeatableDialog(GlobalManager.StoryFileName.TalkToSuJin);
>>>>>>> new
        }
        

    }
}
