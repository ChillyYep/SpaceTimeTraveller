using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockManager : MonoBehaviour {
    public static CodeLockManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Close()
    {
        //关闭密码锁
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
