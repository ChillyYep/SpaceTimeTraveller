using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterTransition : MonoBehaviour {
    public Camera renderCamera;
    public GameObject transitionCanvas;
    public string chapterName;
    public static bool isOver = false;
    public bool isDestroyWhenOver = false;

    private Animator animator;
    public static GameObject currentTransitionCanvas;
    private GameObject textObj;
    private Text text;

    // Use this for initialization
    void Start () {
        currentTransitionCanvas = Instantiate(transitionCanvas);
        currentTransitionCanvas.GetComponent<Canvas>().worldCamera = renderCamera;

        textObj = currentTransitionCanvas.transform.GetChild(0).GetChild(0).gameObject;
        text = textObj.GetComponent<Text>();
        text.text = chapterName;
        animator = textObj.GetComponent<Animator>();
        StartCoroutine(Transition());

    }

    void Update()
    {
        if (isOver && isDestroyWhenOver)
        {
            DestroyImmediate(currentTransitionCanvas);
        }
    }
    IEnumerator Transition()
    {
        yield return new WaitForSeconds(4);
        if (animator != null)
        {
            animator.SetBool("Into", false);//
        }
        yield return new WaitForSeconds(1);
        if(text!=null)
        {
            text.fontSize = 14;
        }
        isOver = true;
    }
}
