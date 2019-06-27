using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBackpack : MonoBehaviour
{
    public string propName;

    protected bool IsExistInBackpack()
    {
        if (BackPackManager.instance != null)
        {
            if (BackPackManager.instance.currentPropsDictionary.ContainsKey(propName))
            {
                return true;
            }
        }
        return false;
    }
}
