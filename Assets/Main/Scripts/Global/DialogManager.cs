using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public List<Sprite> sprites;
    //public List<SpriteRenderer> spriteRenderers;

    //public static Dictionary<string, bool> dictionary;
    public GameObject talkCanvasPrefab;
    [HideInInspector]
    public bool isDarkenCharacterPictrue;
    [HideInInspector]
    public bool isDialogOver = false;

    public static DialogManager instance = null;
    private HashSet<string> dialogFileNameSet= new HashSet<string>();
    private GameObject talkCanvas;
    private GameObject characterPicture;
    private Text nameText;
    private Text dialogContent;
    private Button nextBtn;
    private List<Dialog> dialogs;
    private Sprite currentSprite;
    private SpritesIndexList spritesList;
    private DialogList dialogsList;
    private int index = 0;
    private string currentStoryFileName = null;
    [Serializable]
    public struct Dialog
    {
        public string name;//角色名
        public string say;//说的内容
    }

    [Serializable]
    public struct SpritesIndex
    {
        public string name;//精灵名
        public int index;//索引
    }

    struct SpritesIndexList
    {
        public List<SpritesIndex> spritesList;
    }

    struct DialogList
    {
        public List<Dialog> dialogs;

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        LoadSpritesIndex();
    }
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == GlobalManager.SceneCode.MainUI)
        {
            instance = null;
            DestroyImmediate(gameObject);
        }
    }
    //检测对话事件是否已经发生过了，若未发生，开启对话
    public void AddUnRepeatableDialog(string dialogFileName)
    {
        if (dialogFileNameSet.Contains(dialogFileName))
        {
            Debug.Log("已经存在该文件了");
        }
        else
        {
            dialogFileNameSet.Add(dialogFileName);
            Debug.Log(dialogFileName);
            PlayDialog(dialogFileName);
            currentStoryFileName = dialogFileName;
        }
    }

    public void AddRepeatableDialog(string dialogFileName)
    {
        PlayDialog(dialogFileName);
        currentStoryFileName = dialogFileName;
    }

    //初始化对话画布，加载对话文件
    private void PlayDialog(string dialogFileName)
    {
        isDialogOver = false;
        CharacterController.instance.moveable = false;
        LoadDialogs(dialogFileName);
        if (talkCanvas == null)
        {
            //创建对话画布
            talkCanvas = Instantiate(talkCanvasPrefab);
            index = 0;
            talkCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
            characterPicture = talkCanvas.transform.GetChild(0).Find("CharacterPicture").gameObject;
            nameText = talkCanvas.transform.GetChild(1).Find("Name").GetComponent<Text>();
            dialogContent = talkCanvas.transform.GetChild(1).Find("Say").GetComponent<Text>();
            nextBtn= talkCanvas.transform.GetChild(1).Find("Next").GetComponent<Button>();
            nextBtn.onClick.AddListener(() => { Ding(); Next(); });//按钮监听
        }
        Next();
    }

    //推进对话
    private void Next()
    {
        Dialog dialog;
        //Debug.Log("dialogsList.dialogsList.Count:"+ dialogsList.dialogs.Count);
        if (index< dialogsList.dialogs.Count)
        {
            dialog = dialogsList.dialogs[index++];
            nameText.text = dialog.name + "：";
            dialogContent.text = dialog.say;
            foreach (SpritesIndex spritesIndex in spritesList.spritesList)
            {
                if (spritesIndex.name == dialog.name)
                {
                    if(currentSprite == null||(currentSprite != null && currentSprite != sprites[spritesIndex.index]))
                        currentSprite = sprites[spritesIndex.index];
                    characterPicture.GetComponent<Image>().sprite = currentSprite;
                    if (spritesIndex.index == 0)//如果是主角说话，不呈现立绘
                    {
                        characterPicture.GetComponent<Image>().color = Color.clear;
                    }
                    else
                    {
                        if (isDarkenCharacterPictrue)
                        {
                            characterPicture.GetComponent<Image>().color = Color.black;
                        }
                        else
                        {
                            characterPicture.GetComponent<Image>().color = Color.white;
                        }
                    }
                    break;
                }
            }
            //Debug.Log("nameText:" + nameText.text);
            //Debug.Log("dialogContent:" + dialogContent.text);
        }
        else
        {
            DestroyImmediate(talkCanvas);
            CharacterController.instance.moveable = true;
            isDialogOver = true;
            if (Swicth.instance != null)
            {
                Swicth.instance.SwicthByDialogFileName(currentStoryFileName);//由Switch控制动画开始
            }
        }

    }

    //音效
    private void Ding()
    {
        if (SoundController.instance != null)
        {
            SoundController.instance.PlaySoundEffect(SoundController.SoundEffect.DIALOG);
        }
    }

    private void LoadSpritesIndex()
    {
        FileStream fileStream = null;
        try
        {
            fileStream = new FileStream(GlobalManager.PathName.SpritesIndexPath, FileMode.Open, FileAccess.Read);
        }
        catch
        {
            return;
        }
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(fileStream,Encoding.Default);
        }
        catch
        {
            return;
        }
        string spriteIndexJSON = "";
        spriteIndexJSON = sr.ReadToEnd();
        Debug.Log("spritesIndex:" + spriteIndexJSON);
        spritesList = JsonUtility.FromJson<SpritesIndexList>(spriteIndexJSON);
        sr.Close();
        fileStream.Close();
    }

    private void LoadDialogs(string dialogFileName)
    {
        FileStream fileStream = null;
        try
        {
            fileStream = new FileStream(GlobalManager.PathName.DialogPath+"/"+ dialogFileName, FileMode.Open, FileAccess.Read);
        }
        catch
        {
            return;
        }
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(fileStream, Encoding.Default);
        }
        catch
        {
            return;
        }
        string dialogsJSON = "";
        dialogsJSON = sr.ReadToEnd();
        Debug.Log("dialogsJSON:" + dialogsJSON);
        dialogsList = JsonUtility.FromJson<DialogList>(dialogsJSON);
        sr.Close();
        fileStream.Close();
    }
}
