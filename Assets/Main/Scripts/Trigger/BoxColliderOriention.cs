using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderOriention : MonoBehaviour {
    public bool enableUpTrigger = false;
    public bool enableDownTrigger = false;
    public bool enableLeftTrigger = false;
    public bool enableRightTrigger = false;

    private BoxCollider2D boxCollider2D;
    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vector = collision.contacts[0].normal;
        if (vector.y < 0 && enableUpTrigger)
        {
            Debug.Log("从上方相撞");
            boxCollider2D.isTrigger = true;
        }
        else if (vector.y > 0 && enableDownTrigger)
        {
            Debug.Log("从下方相撞");
            boxCollider2D.isTrigger = true;
        }
        else if (vector.x < 0 && enableRightTrigger)
        {
            Debug.Log("从右方相撞");
            boxCollider2D.isTrigger = true;
        }
        else if (vector.x > 0 && enableLeftTrigger)
        {
            Debug.Log("从左方相撞");
            boxCollider2D.isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("离开物体");
        boxCollider2D.isTrigger = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("进入物体");
        boxCollider2D.isTrigger = false;
    }
}
