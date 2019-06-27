using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class GloabalManager
{
    public class PathNameManager
=======
public class GlobalManager
{
    public class PathName
>>>>>>> new
    {
        public static readonly string MonologuePath = Application.streamingAssetsPath + "/Story/Monologue/";
        public static readonly string DialogPath=Application.streamingAssetsPath + "/Story/Dialog/";
        public static readonly string SettingPath = Application.streamingAssetsPath + "/Config/Setting.json";//设置文件唯一
        public static readonly string SpritesIndexPath = Application.streamingAssetsPath + "/Config/Characters.json";
        public static readonly string PropsPath = Application.streamingAssetsPath + "/Config/Props.json";//道具列表
        public static readonly string ArchivePath = Application.streamingAssetsPath + "/Archive";//多个存档
    }

    public class StoryFileName
    {
        public const string CastleIndoor1 = "CastleIndoor1.json";
        public const string CastleIndoor2 = "CastleIndoor2.json";
        public const string CastleOutdoor1 = "CastleOutdoor1.json";
        public const string CastleOutdoor2 = "CastleOutdoor2.json";
        public const string FriaBedroom1 = "FriaBedroom1.json";
        public const string FriaBedroom2 = "FriaBedroom2.json";
        public const string FriaBedroom3 = "FriaBedroom3.json";
        public const string FriaBedroom4 = "FriaBedroom4.json";
        public const string FriaBedroomFound = "FriaBedroomFound.json";
        public const string FriaBedroomNoFound = "FriaBedroomNoFound.json";
        public const string GalleryOutdoor1 = "GalleryOutdoor1.json";
        public const string GalleryOutdoor2 = "GalleryOutdoor2.json";
        public const string Studio1 = "Studio1.json";
        public const string TalkToAyr1 = "TalkToAyr1.json";
        public const string TalkToAyr2 = "TalkToAyr2.json";
        public const string TalkToAyr3 = "TalkToAyr3.json";
        public const string TalkToAyr4 = "TalkToAyr4.json";
        public const string TalkToSuJin = "TalkToSuJin.json";
        public const string BadEnd = "BadEnd.json";
    }
<<<<<<< HEAD
    public class LayerNameManager
=======
    public class LayerName
>>>>>>> new
    {
        public const string BackgroundLayer = "Background";
        public const string UILayer = "UI";
        public const string DialogLayer = "Dialog";
    }
<<<<<<< HEAD
    public class SceneCodeManager
=======
    public class SceneCode
>>>>>>> new
    {
        public const string MainUI = "MainUI";
        public const string BeforeGame1 = "BeforeGame1";
        public const string BeforeGame2 = "BeforeGame2";
        public const string BeforeGame3 = "BeforeGame3";
        //public const string CastleOutdoor = "CastleOutdoor";
        //public const string CastleIndoor = "CastleIndoor";
        //public const string FriaBedroom = "FriaBedroom";
        public const string FirstChapter = "FirstChapter";
        public const string SecondChapter = "SecondChapter";
        public const string HappyEnd = "HappyEnd";
        public const string BadEnd = "BadEnd";

        public static void ChangeScene(string sceneCode)
        {
            string sceneName = null;
            bool isSave = false;
            bool isLoading = false;
            switch (sceneCode)
            {
                case MainUI:
                    isLoading = true;
                    break;
                case BeforeGame1:
                case BeforeGame2:
                case BeforeGame3:
<<<<<<< HEAD
                    sceneName = SceneNameManager.BeforeGame;
                    break;
                //case CastleOutdoor:
                //    sceneName = SceneNameManager.FirstChapter;
                //    isSave = true;
                //    break;
                //case CastleIndoor:
                //    sceneName = SceneNameManager.FirstChapter;
                //    break;
                //case FriaBedroom:
                //    sceneName = SceneNameManager.FirstChapter;
                //break;
                case FirstChapter:
                    sceneName = SceneNameManager.FirstChapter;
=======
                    sceneName = SceneName.BeforeGame;
                    break;
                case FirstChapter:
                    sceneName = SceneName.FirstChapter;
>>>>>>> new
                    isSave = true;
                    isLoading = true;
                    break;
                case SecondChapter:
<<<<<<< HEAD
                    sceneName = SceneNameManager.SecondChapter;
=======
                    sceneName = SceneName.SecondChapter;
>>>>>>> new
                    isSave = true;
                    isLoading = true;
                    break;
                case BadEnd:
                case HappyEnd:
<<<<<<< HEAD
                    sceneName = SceneNameManager.FinalChapter;
=======
                    sceneName = SceneName.FinalChapter;
>>>>>>> new
                    isSave = true;
                    isLoading = true;
                    break;
                default:
                    break;
            }
<<<<<<< HEAD
            //if (sceneName != null && SaveAndLoad.instance != null && BackPackManager.instance != null)
            //{
            //    SaveAndLoad.instance.SetCurrentArchive(sceneName, sceneCode, BackPackManager.instance.GetPropNames());
            //}
=======
>>>>>>> new
            if (isSave)//自动保存
            {
                if (SaveAndLoad.instance != null && SaveAndLoad.instance.currentArchive != null && BackPackManager.instance != null)
                {
                    SaveAndLoad.instance.SetCurrentArchive(sceneName, sceneCode, BackPackManager.instance.GetPropNames());
                    SaveAndLoad.instance.SaveArchive();
                }
            }
            if (isLoading)
            {
                Loading.nextSceneName = sceneCode;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneCode);
            }
        }
    }
<<<<<<< HEAD
    public class SceneNameManager
=======
    public class SceneName
>>>>>>> new
    {
        public const string BeforeGame = "序章";
        public const string FirstChapter = "第一章";
        public const string SecondChapter = "第二章";
        public const string FinalChapter = "终章";
    }

    public class Tips
    {
        public const string SpaceToEnterTip = "按<color=red>空格</color>进入";
        public const string DoorIsClose = "门被锁了";
        public const string TakeProp = "按<color=red>Z</color>拾取物品";
        public const string IntoOther = "按<color=red>X</color>进入操作界面";
        public const string GetSomeProp1 = "获得<color=red>{0}</color>";
        public const string GetSomeProp2 = "获得<color=red>{0}</color>、<color=red>{1}</color>";
        public const string LoseSomeProp = "失去<color=red>{0}</color>";
        public const string TalkToSomeone = "按<color=red>X</color>与人交谈";
        public const string DontTouchProp = "未经同意还是不要乱动为好";
        public const string DontTouchDoor = "未经同意还是不要进入为好";

    }
}
