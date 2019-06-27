using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetectBackpack : DetectBackpack
{
    private DoorTrigger trigger;

    void Awake()
    {
        trigger = GetComponent<DoorTrigger>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsExistInBackpack() && !trigger.enableEnter)
        {
            trigger.enableEnter = true;
            trigger.ShowTip();
        }
    }
}
