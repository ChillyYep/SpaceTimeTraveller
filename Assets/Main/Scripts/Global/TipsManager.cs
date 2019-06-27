using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour {
    public static TipsManager instance = null;
    private Animator animator;
    private Text tipText;
    private const string animationName1 = "TipsBoxFlyIn";
    //private const string animationName2 = "TipsBoxFlyIdle";


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        tipText = transform.GetChild(0).GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    public void FlyIn(string tip)
    {
        tipText.text = tip;
        animator.Play(animationName1);
    }
}
