using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArchiveInfo : MonoBehaviour
{
    //public Transform LoadArchiveBtnTransform;
    //public GameObject DelArchiveBtn;
    public Transform ChapterNum;
    public Transform Time;

    private ReadWriteArchive.Archive archive = null;

    public void Init(ReadWriteArchive.Archive archive)
    {
        this.archive = archive;
        ChapterNum.GetComponent<TextMeshProUGUI>().text = archive.sceneName;
        Time.GetComponent<TextMeshProUGUI>().text = archive.lastSaveTime;
    }

    public void LoadArchive()
    {
        //ReadWriteArchive.GetInstance().LoadArchive(fileName);
        if (SaveAndLoad.instance != null)
        {
            SaveAndLoad.instance.LoadArchive(archive.fileName);
        }
        Debug.Log(string.Format("Click No.{0} LoadArchiveBtn!", archive.fileName));
    }

    public void DeleteArchive()
    {
        Debug.Log(string.Format("Click No.{0} DeleteArchiveBtn!", archive.fileName));
        SaveAndLoad.instance.DeleteArchive(archive.fileName);
        gameObject.GetComponent<Animator>().Play("ItemDisappear");
        Debug.Log(Time.GetComponent<TextMeshProUGUI>().text);
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.35f);
        DestroyImmediate(gameObject);
    }
}
