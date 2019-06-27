using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCollider : MonoBehaviour {
    private BoxCollider2D bc2D;
    public PolygonCollider2D pc2D;

    void Awake()
    {
        bc2D = GetComponent<BoxCollider2D>();
        //pc2D = GetComponent<PolygonCollider2D>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if(!pc2D.isTrigger)
            pc2D.isTrigger = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       // if(pc2D.isTrigger)
            pc2D.isTrigger = false;
    }
}
