using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeGame : MonoBehaviour {
    
    public GameObject paperPlane;
    
    private Animator animator;
    private AnimatorStateInfo animatorStateInfo;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();//纸飞机动画
        paperPlane.SetActive(false);
        animator.SetBool("Play", false);
    }

    // Update is called once per frame
    void Update () {
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName("PagePlaneFly") && animatorStateInfo.normalizedTime >= 1.0f)
        {
            TextFadeInOut.isPlayOtherAnim = false;
            if (paperPlane != null)
            {
                paperPlane.SetActive(true);
            }
        }
        if (Dialog1Control.isPlayOther)
        {
            animator.SetBool("Play", true);
        }
    }
}
