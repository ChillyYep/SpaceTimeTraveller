using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadWriteArchive{
    public List<Archive> archives;

    private List<string> fileList;
    private static ReadWriteArchive readWriteArchive;
    private readonly string suffix = ".json";//文件格式为json
    //private Archive currentArchive;
<<<<<<< HEAD
    private readonly string ArchivePath = GloabalManager.PathNameManager.ArchivePath;
=======
    private readonly string ArchivePath = GlobalManager.PathName.ArchivePath;
>>>>>>> new
    //private string fileName;
    //存档类
    public class Archive
    {
        public string sceneName;//场景名，中文
        public string sceneCode;//场景代号，变量名
        public List<string> propNames;//道具列表
        public string lastSaveTime;//上次存储时间
        [SerializeField]
        private string _fileName;//文件名
        public string fileName
        {
            get
            {
                return _fileName;
            }
        }
        public Archive() { }
        public Archive(string sceneName,string sceneCode, string fileName,List<string> propNames, string lastSaveTime)
        {
            this.sceneName = sceneName;
            this.sceneCode = sceneCode;
            this.propNames = propNames;
            _fileName = fileName;
            this.lastSaveTime = lastSaveTime;
        }
    }

    private ReadWriteArchive()
    {
        UpdateArchives();
    }

    //重读文件列表，并根据这些文件修改存档列表
    public void UpdateArchives()
    {
        fileList = ReadFileList();
        //foreach(string filename in fileList)
        //{
        //    Debug.Log("ReadWriteArchive:" + filename);
        //}
        archives = GetArchives();
        //readWriteArchive = new ReadWriteArchive();
    }

    //读取文件列表
    private List<string> ReadFileList()
    {
        //获取路径下的所有存档文件
        DirectoryInfo root = new DirectoryInfo(ArchivePath);
        List<string> fileList = new List<string>();
        foreach(FileInfo fileInfo in root.GetFiles().Where(filename => filename.Name.EndsWith(suffix)))
        {
            fileList.Add(fileInfo.Name);
            Debug.Log("fileInfo:" + fileInfo.Name);
        }
        return fileList;
    }

    //单例模式
    public static ReadWriteArchive GetInstance()
    {
        if (readWriteArchive == null)
        {
            readWriteArchive = new ReadWriteArchive();
            Debug.Log("Create new ReadWriteArchive");
        }
        return readWriteArchive;
    }



    //获取所有存档，为读取存档面板提供存档基本信息
    private List<Archive> GetArchives()
    {
        List<Archive> archives = new List<Archive>();
        FileStream fileStream;
        StreamReader sr;
        Debug.Log("GetArchive!");
        foreach (string fileName in fileList)
        {
            fileStream = File.OpenRead(ArchivePath + "/" + fileName);
            try
            {
                sr = new StreamReader(fileStream);
            }
            catch
            {
                fileStream.Close();
                return archives;
            }
            Debug.Log("GetArchive.fileName:" + fileName);
            archives.Add(JsonUtility.FromJson<Archive>(sr.ReadLine()));
            fileStream.Close();
        }
        return archives;
    }

    //读取某个存档
    public Archive LoadArchive(string fileName)
    {
        Archive archive = null;
        FileStream fileStream = new FileStream(ArchivePath + "/" + fileName + suffix, FileMode.Open, FileAccess.Read);
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(fileStream);
        }
        catch
        {
            fileStream.Close();
            return null;
        }
<<<<<<< HEAD
        string ArchiveJson = sr.ReadLine();
        archive = JsonUtility.FromJson<Archive>(ArchiveJson);
=======
        //读档
        string ArchiveJson = sr.ReadLine();//sr为文件输出流
        archive = JsonUtility.FromJson<Archive>(ArchiveJson);//json对象转换为Archive对象
>>>>>>> new
        sr.Close();
        fileStream.Close();
        return archive;
    }

    //保存存档
    public void SaveArchive(Archive archive)
    {
        //修改存档数据
        archive.lastSaveTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        //currentArchive.sceneName = sceneName;
        //currentArchive.sceneCode = sceneCode;
        //currentArchive.props = props;
        //currentArchive.tasks = tasks;

        FileStream fileStream = new FileStream(ArchivePath + "/" + archive.fileName + suffix, FileMode.Truncate, FileAccess.Write);
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter(fileStream);
        }
        catch
        {
            fileStream.Close();
            return;
        }
<<<<<<< HEAD
        sw.WriteLine(JsonUtility.ToJson(archive));
=======
        //存档
        sw.WriteLine(JsonUtility.ToJson(archive));//sw为文件输入流，将Archive对象转化为json对象
>>>>>>> new
        sw.Flush();
        sw.Close();

    }
    //创建存档
    public Archive CreateArchive()
    {
        Archive archive = null;
        //生成存档
        DateTime dateTime = DateTime.Now;
        string dateTimeFormat1 = dateTime.ToString("yyyy_MM_dd_hh_mm_ss");
        string dateTimeFormat2 = dateTime.ToString("yyyy/MM/dd hh:mm:ss");
        FileStream fileStream = new FileStream(ArchivePath + "/" + dateTimeFormat1 + suffix, FileMode.Create, FileAccess.Write);
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter(fileStream);
        }
        catch
        {
            fileStream.Close();
            return null;
        }
<<<<<<< HEAD
        archive = new Archive(GloabalManager.SceneNameManager.BeforeGame, GloabalManager.SceneCodeManager.BeforeGame1, dateTimeFormat1, new List<string>(), dateTimeFormat2);
=======
        archive = new Archive(GlobalManager.SceneName.BeforeGame, GlobalManager.SceneCode.BeforeGame1, dateTimeFormat1, new List<string>(), dateTimeFormat2);
>>>>>>> new
        string ArchiveJson = JsonUtility.ToJson(archive);
        sw.WriteLine(ArchiveJson);
        Debug.Log("ArchiveJson:" + ArchiveJson);
        sw.Flush();
        sw.Close();
        fileStream.Close();
        Debug.Log("存档名为:"+ dateTimeFormat1);

        return archive;
    }

    //删除存档
    public void DeleteArchive(string filename)
    {
        File.Delete(ArchivePath + "/" + filename + suffix);
        fileList.Remove(filename);
        foreach(Archive archive in archives)
        {
            if (archive.fileName == filename)
            {
                archives.Remove(archive);
                break;
            }
        }
    }
}
