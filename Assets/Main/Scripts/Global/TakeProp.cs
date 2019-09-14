using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeProp : MonoBehaviour {
    private AddProp addProp;
    void Awake()
    {
        addProp = GetComponent<AddProp>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (TipsManager.instance != null)
        {
            TipsManager.instance.FlyIn(GlobalManager.Tips.TakeProp);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            addProp.Do();
            //Destroy(gameObject);
            //DestroyImmediate(gameObject);
        }
    }
}
