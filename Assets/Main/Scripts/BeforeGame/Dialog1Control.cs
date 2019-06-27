using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog1Control : MonoBehaviour {
    //private GameObject dialog;
    public static bool isPlayOther = false;

    private Animator animator;
    private AnimatorStateInfo animatorStateInfo;

    private GameObject story;
    private RectTransform storyTransform;
    private RectTransform rectTransform;


    private Vector2 storySize;
    //private Vector2 size;
    private Text text;
    private Button nextBtn;
    private Image nextBtnImage;
    private Image dialogImage;
    //private readonly Color startColor = new Color(1f, 1f, 1f, 0f);
    // Use this for initialization
    void Start () {
        dialogImage = GetComponent<Image>();
        rectTransform = (RectTransform)transform;

        nextBtn = transform.Find("NextBtn").gameObject.GetComponent<Button>();
        nextBtnImage = transform.Find("NextBtn").gameObject.GetComponent<Image>();

        story = transform.Find("Story").gameObject;
        text = story.GetComponent<Text>();
        storyTransform = story.GetComponent<RectTransform>();
        storySize = storyTransform.rect.size;

        animator = GetComponent<Animator>();
        TextFadeInOut.isPlayTextFadeInOut = false;
        HideAll();
        StartCoroutine(showStoryPanel());
        //Debug.Log("Dialog1Control:Start");
        //Debug.Log("TextFadeInOut.isPlayTextFadeInOut:" + TextFadeInOut.isPlayTextFadeInOut);

    }

    // Update is called once per frame
    void Update () {
        if (storyTransform.rect.size != storySize)
        {
            storySize = storyTransform.rect.size;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, storySize.y + 40);
        }

        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName("PanelFade") && animatorStateInfo.normalizedTime >= 1.0f)//PanelFade动画播放完毕
        {
            //Debug.Log("TextFadeInOut.isPlayTextFadeInOut:"+ TextFadeInOut.isPlayTextFadeInOut);
            if (!TextFadeInOut.isPlayTextFadeInOut)//使按钮可用且播放文本淡入淡出动画
            {
                TextFadeInOut.isPlayTextFadeInOut = true;
                nextBtn.enabled = true;
                nextBtnImage.enabled = true;
                Debug.Log("PanelFade isOver!");
            }
        }
        if (TextFadeInOut.isPlayOtherAnim)
        {
            if (dialogImage.isActiveAndEnabled)
            {
                HideAll();
                isPlayOther = true;
                text.enabled = false;
            }
            TextFadeInOut.isPlayOtherAnim = false;
        }
    }

    private void HideAll()
    {
        dialogImage.enabled = false;
        nextBtn.enabled = false;
        nextBtnImage.enabled = false;
        animator.enabled = false;
    }

    IEnumerator showStoryPanel()
    {
        yield return new WaitForSeconds(1);
        dialogImage.enabled = true;
        animator.enabled = true;
    }
}
