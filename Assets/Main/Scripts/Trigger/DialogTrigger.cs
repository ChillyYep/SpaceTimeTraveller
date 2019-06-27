using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {
    public string dialogFileName;
    public bool isDarkenCharacterPictrue = false;
    public bool canTrigger = true;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTrigger)
        {
            if (DialogManager.instance != null)
            {
                DialogManager.instance.isDarkenCharacterPictrue = isDarkenCharacterPictrue;
                DialogManager.instance.AddUnRepeatableDialog(dialogFileName);
            }
        }
    }
}
