using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateArchiveElements : MonoBehaviour {

    public GameObject ArchiveItem;
    public static CreateArchiveElements instance = null;
    //public static bool isUpdate = false;
    private List<ReadWriteArchive.Archive> archives;
    ReadWriteArchive readWriteArchive;
    private List<GameObject> ArchiveItemList;
    //int index = 0;

    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        ArchiveItemList = new List<GameObject>();
        readWriteArchive = ReadWriteArchive.GetInstance();
        UpdateArchivesPanel();
    }

    public void UpdateArchivesPanel()
    {
        DestroyArchivePanel();
        readWriteArchive.UpdateArchives();
        archives = readWriteArchive.archives;
        GameObject tempArchiveItem;
        foreach (ReadWriteArchive.Archive archive in archives)
        {
            tempArchiveItem = Instantiate(ArchiveItem, transform);
            ArchiveItemList.Add(tempArchiveItem);
            tempArchiveItem.GetComponent<ArchiveInfo>().Init(archive);
        }
    }

    void DestroyArchivePanel()
    {
        //while (transform.childCount > 0)
        //{
        //    DestroyImmediate(transform.GetChild(0));
        //}
        foreach(GameObject item in ArchiveItemList)
        {
            Destroy(item);
        }
        ArchiveItemList.Clear();
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //}
        //transform.DetachChildren();
    }
}
