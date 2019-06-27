using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeforeGame1Manager : MonoBehaviour {
    
    public Canvas letterCanvas;
    public GameObject paperPlane;
    
    // Use this for initialization
    void Start () {
        letterCanvas.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showLetterCanvas()
    {
        letterCanvas.gameObject.SetActive(true);
        paperPlane.GetComponent<Button>().interactable = false;
        paperPlane.GetComponent<Image>().enabled = false;
    }

    public void hideLetterCanvas(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
