using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddProp : MonoBehaviour {
    public List<string> propNames=new List<string>();
    //void Start()
    //{
    //    if (BackPackManager.instance != null && BackPackManager.instance.currentPropsDictionary.ContainsKey(propName))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    //添加到道具字典
    public void Do()
    {
        if (BackPackManager.instance != null)
        {
            BackPackManager.instance.AddProp(propNames);
            Destroy(gameObject);
            //Debug.Log("Add " + propName);
        }
    }
}
