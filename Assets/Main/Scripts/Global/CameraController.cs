using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject mainCharacter;
    public GameObject canvasArea;
<<<<<<< HEAD
    //public GameObject[] doors;
    //public static GameObject currentDoor = null;
    //public static Vector3 characterPos = Vector3.zero;
=======
>>>>>>> new

    public static CameraController instance = null;
    [HideInInspector]
    public bool pauseControllCamera = false;
    public delegate void AfterCameraMove();
    public event AfterCameraMove _afterCameraMove;
<<<<<<< HEAD
    public event AfterCameraMove afterCameraMove
    {
        add
        {
            
            _afterCameraMove += value;
        }
        remove
        {

        }
    }
=======
>>>>>>> new
    private float rightCriticalPointX;
    private float leftCriticalPointX;
    private const float startPosX = 1.0f;
    float cameraWidth;
    float canvasCenter;
    float canvasWidth;
    private Vector3 deltaVector=Vector3.zero;
    private const float secondPerFrame = 0.04f;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        Camera camera = gameObject.GetComponent<Camera>();
        cameraWidth = camera.orthographicSize * 2 * camera.aspect;

        UpdateCriticalPoint();

        //人物位置
        //if (characterPos == Vector3.zero)//初始点位置
        //{
        mainCharacter.transform.position = new Vector3(canvasCenter - canvasWidth / 2 + startPosX, mainCharacter.transform.position.y, 0.0f);
        //相机位置
        transform.position = new Vector3(leftCriticalPointX, transform.position.y, transform.position.z);
        if (deltaVector == Vector3.zero)
        {
            deltaVector = mainCharacter.transform.position - transform.position;
            deltaVector.x = 0.0f;
        }
<<<<<<< HEAD
        //}
        //else//出门位置
        //{
        //    mainCharacter.transform.position = characterPos;
        //    transform.position = mainCharacter.transform.position - deltaVector;
        //    characterPos = Vector3.zero;
        //}
        //Debug.Log("canvasCenter:" + canvasCenter);

        //相机位置
        //if (deltaVector == Vector3.zero) {
        //    transform.position = new Vector3(leftCriticalPointX, transform.position.y, transform.position.z);
        //    deltaVector = mainCharacter.transform.position - transform.position;
        //    deltaVector.x = 0.0f;
        //}
        //else
        //{
        //    transform.position = mainCharacter.transform.position - deltaVector;
        //}
=======
>>>>>>> new
    }

    void FixedUpdate()
    {
        if (!pauseControllCamera)
        {
            if(mainCharacter.transform.position.x<rightCriticalPointX && mainCharacter.transform.position.x > leftCriticalPointX)
            {
                transform.position = mainCharacter.transform.position - deltaVector;
            }
            else if(mainCharacter.transform.position.x <= leftCriticalPointX)
            {
                transform.position = new Vector3(leftCriticalPointX, mainCharacter.transform.position.y, mainCharacter.transform.position.z) -deltaVector;
            }
            else if (mainCharacter.transform.position.x >= rightCriticalPointX)
            {
                transform.position = new Vector3(rightCriticalPointX, mainCharacter.transform.position.y, mainCharacter.transform.position.z) - deltaVector;
            }
        }
    }

    public void UpdateCriticalPoint()
    {
        canvasWidth = canvasArea.GetComponent<SpriteRenderer>().size.x * canvasArea.transform.localScale.x;
        canvasCenter = canvasArea.transform.position.x;
        rightCriticalPointX = canvasCenter + (canvasWidth - cameraWidth) / 2;
        leftCriticalPointX = canvasCenter - (canvasWidth - cameraWidth) / 2;
    }

    public void AutoMove2RightAnim()
    {
        StartCoroutine(AutoMoveToRightAnim());
    }

    IEnumerator AutoMoveToRightAnim()
    {
        float deltaDistance = rightCriticalPointX - transform.position.x;
        float frameCount = 25;
        CharacterController.instance.moveable = false;
        CharacterController.instance.StopWalkAnim();
        pauseControllCamera = true;//回收摄像头控制权

        //CharacterController.instance.ShowExclam();
        //yield return new WaitForSeconds(1.0f);
        //CharacterController.instance.HideExclam();

        //移动摄像头
        for (int i = 0; i < frameCount; i++)
        {
            yield return new WaitForSeconds(secondPerFrame);
            transform.position += new Vector3(deltaDistance / frameCount, 0, 0);
        }
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < frameCount; i++)
        {
            yield return new WaitForSeconds(secondPerFrame);
            transform.position -= new Vector3(deltaDistance / frameCount, 0, 0);
        }
        pauseControllCamera = false;
        CharacterController.instance.moveable = true;
        _afterCameraMove();
    }
}
