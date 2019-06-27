using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoader : MonoBehaviour {

    public GameObject UIPanel;
    void Awake()
    {
        if (UIController.instance == null)
        {
            Instantiate(UIPanel);
        }
    }

}
