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
<<<<<<< HEAD
            TipsManager.instance.FlyIn(GloabalManager.Tips.TakeProp);
=======
            TipsManager.instance.FlyIn(GlobalManager.Tips.TakeProp);
>>>>>>> new
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
