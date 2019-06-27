using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private static string _nextSceneName;
    private static string _preSceneName;
    public static string nextSceneName
    {
        get
        {
            return _nextSceneName;
        }
        set
        {
            _nextSceneName = value;
            _preSceneName = SceneManager.GetActiveScene().name;
        }
    }

    public Sprite HappyEndImage;
    public Sprite BadEndImage;
    public GameObject Background;

    private const float duration = 2.0f;
    private AsyncOperation asyn;
    void Start()
    {
<<<<<<< HEAD
        if (_preSceneName == GloabalManager.SceneCodeManager.HappyEnd)
=======
        if (_preSceneName == GlobalManager.SceneCode.HappyEnd)
>>>>>>> new
        {
            if (Background != null)
            {
                Background.GetComponent<Image>().sprite = HappyEndImage;
                Background.GetComponent<Image>().color = Color.white;
            }
        }
<<<<<<< HEAD
        else if (_preSceneName == GloabalManager.SceneCodeManager.BadEnd)
=======
        else if (_preSceneName == GlobalManager.SceneCode.BadEnd)
>>>>>>> new
        {
            if (Background != null)
            {
                Background.GetComponent<Image>().sprite = BadEndImage;
                Background.GetComponent<Image>().color = Color.white;
            }
        }
        StartCoroutine("loadNextScene");
        //StartCoroutine
    }

    IEnumerator loadNextScene()
    {
        yield return new WaitForSeconds(duration);
        if (nextSceneName != null && SceneManager.GetActiveScene().name == "Loading")
        {
            //asyn = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextSceneName);
            asyn = SceneManager.LoadSceneAsync(nextSceneName);
        }
        yield return asyn;
    }

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(0);
    //}
}
