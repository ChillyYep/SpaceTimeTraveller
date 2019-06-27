using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour {

    private const int MaxAmount = 4;
    private Stack<int> numStack = new Stack<int>();//显示屏上的序列
    private int ptr = 0;
    private int[] code = { 1, 5, 4, 2 };//正确密码

<<<<<<< HEAD
=======
    //显示区域四个格子
>>>>>>> new
    public Image[] showAreas = new Image[MaxAmount];
    //索引0为Blank，索引1-10为0-9的数字
    public Sprite[] numSprites = new Sprite[11];
    //索引0-9为数字0-9，索引10、11分别是Del，Ac
    //public Button[] btns = new Button[12];
    public GameObject safeDoor;

    private Animator safeDoorAnimator;
    void Awake()
    {
        safeDoorAnimator = safeDoor.GetComponent<Animator>();
    }

    public void OnNum(int num)
    {
        Push(num);
    }

    public void OnDel()
    {
        Pop();
    }

    public void OnAc()
    {
        Clear();
    }

    private void Push(int num)
    {
        if (num > 9 || num < 0)
            return;
        if (numStack.Count < MaxAmount)//添加数字
        {
            numStack.Push(num);
            showAreas[ptr++].sprite = numSprites[num];
        }

        if (numStack.Count == MaxAmount)//判断是否是目标代码
        {
            bool isCorrect = true;
            int i = code.Length;
            foreach(int element in numStack)
            {

                if (code[--i] != element)
                {
                    isCorrect = false;
                    break;
                }
            }
            if (isCorrect)
            {
                Debug.Log("密码正确!");
                if (CodeLockManager.instance != null)
                {
                    CodeLockManager.instance.Close();
                }
                safeDoorAnimator.Play("OpenDoor");
            }
        }
    }

    private void Pop()
    {
        if (numStack.Count > 0)
        {
            numStack.Pop();
            showAreas[--ptr].sprite = numSprites[10];//索引10为Blank
        }
    }

    private void Clear()
    {
        numStack.Clear();
        while (ptr > 0)
        {
            showAreas[--ptr].sprite = numSprites[10];
        }
    }
}
