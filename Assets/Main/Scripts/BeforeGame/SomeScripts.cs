using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomeScripts : MonoBehaviour {
    public GameObject dialog;
    public string filename;

    private Animator animator;
    private AnimatorStateInfo animatorStateInfo;
    private GameObject currentTransitionCanvas;
    private List<string> scripts;
    private int index = -1;
    private GameObject textObj;
    private Text text;
    private const float waitSeconds = 3.0f;

    void Awake()
    {
        if (dialog != null)
        {
            dialog.SetActive(false);
        }
    }
    // Use this for initialization
    void Start () { 
        scripts = ReadStory.GetStoryReader().readFile(GlobalManager.PathName.MonologuePath + filename);
        if (scripts.Count != 0)
        {
            index = 0;
        }

    }

    // Update is called once per frame
    void Update () {
        if (ChapterTransition.isOver)
        {
            if (currentTransitionCanvas == null && ChapterTransition.currentTransitionCanvas != null)
            {
                currentTransitionCanvas = ChapterTransition.currentTransitionCanvas;
                textObj = currentTransitionCanvas.transform.GetChild(0).GetChild(0).gameObject;
                text = textObj.GetComponent<Text>();
                animator = textObj.GetComponent<Animator>();
            }
            if (animator != null)
            {
                animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
                if (animatorStateInfo.IsName("FadeOut") && animatorStateInfo.normalizedTime >= 1.0f)
                {
                    StartCoroutine(FadeIn());
                }
            }
        }
    }

    IEnumerator FadeIn()
    {
        if (index < scripts.Count)
        {
            text.text = scripts[index++];
            animator.SetBool("Into", true);//FadeIn
            yield return new WaitForSeconds(waitSeconds);
            animator.SetBool("Into", false);//FadeOut
        }
        else
        {
            Destroy(currentTransitionCanvas);
            if (dialog != null)
            {
                dialog.SetActive(true);
            }
        }
    }
}
