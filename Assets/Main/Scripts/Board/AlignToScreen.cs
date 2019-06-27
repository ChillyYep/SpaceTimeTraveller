using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AlignToCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != Camera.main.transform.position.x)
        {
            AlignToCamera();
        }
    }

    void AlignToCamera()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
    }
}
