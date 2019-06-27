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
<<<<<<< HEAD
        canvas.sortingLayerName = GloabalManager.LayerNameManager.BackgroundLayer;
=======
        canvas.sortingLayerName = GlobalManager.LayerName.BackgroundLayer;
>>>>>>> new
        canvas.sortingOrder = -1;
    }

}
