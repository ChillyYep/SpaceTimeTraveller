using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBlockPosition : MonoBehaviour {
    private Scrollbar scrollbarY;
	// Use this for initialization
	void Start () {
        scrollbarY = GetComponent<Scrollbar>();
        scrollbarY.value = 1f;
        scrollbarY.direction = Scrollbar.Direction.BottomToTop;
    }
	
}
