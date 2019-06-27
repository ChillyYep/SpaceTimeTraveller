using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject saveAndLoadManager;
    public GameObject soundController;

    void Awake()
    {
        if (SoundController.instance == null)
        {
            Instantiate(soundController);
        }
        if (SaveAndLoad.instance == null)
        {
            Instantiate(saveAndLoadManager);
        }
    }
}
