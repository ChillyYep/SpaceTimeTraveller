using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {

    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        //sortingLayerName = canvas.sortingLayerName;
    }
    public void GoBack()
    {
        canvas.sortingLayerName = GlobalManager.LayerName.BackgroundLayer;
        canvas.sortingOrder = -1;
    }

}
