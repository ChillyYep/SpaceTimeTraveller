using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger2 : MonoBehaviour {
    //public Vector3 characterPos = Vector3.zero;
    public GameObject posPoint;
    public GameObject character;
    public GameObject canvasArea;

    //public string sceneName;
    private bool enableEnter = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (enableEnter)
        {
            //CameraController.characterPos = characterPos;
            if (posPoint != null && character != null && canvasArea != null)
            {
                CameraController.instance.canvasArea = canvasArea;
                CameraController.instance.UpdateCriticalPoint();
                character.transform.position = posPoint.transform.position;
            }
            //characterPos = Vector3.zero;
            //GloabalManager.SceneCodeManager.ChangeScene(sceneName);
        }
    }
}
