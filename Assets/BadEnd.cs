using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnd : MonoBehaviour
{
    private bool hasToBadEnd = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (TipsManager.instance != null)
        {
            TipsManager.instance.FlyIn("按Space确认BadEnd");
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!hasToBadEnd && Input.GetKeyDown(KeyCode.Space))
        {
            if (Swicth.instance != null)
            {
                Swicth.instance.BadEnd();
                hasToBadEnd = true;
            }
        }
    }
}
