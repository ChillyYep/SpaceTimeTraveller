using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadWriteSetting {
    public class Setting
    {
        public float musicVolumn;
        public Setting()
        {
            musicVolumn = 0.5f;
        }
        public Setting(float volumn)
        {
            musicVolumn=volumn;
        }
    }

    private static ReadWriteSetting readWirteSetting;
    private Setting setting;
    private FileStream fileStream;
<<<<<<< HEAD

    //private Setting setting;
=======
    
>>>>>>> new
    private ReadWriteSetting()
    {
        setting = new Setting();
    }
    public static ReadWriteSetting GetInstance()
    {
        if (readWirteSetting == null)
        {
            readWirteSetting = new ReadWriteSetting();
        }
        return readWirteSetting;
    }
    public Setting GetSetting()
    {
        return setting;
    }
    public Setting ReadSetting()
    {
        try
        {
<<<<<<< HEAD
            fileStream = new FileStream(GloabalManager.PathNameManager.SettingPath, FileMode.Open,FileAccess.ReadWrite);
        }
        catch
        {
            //fileStream = new FileStream(PathManager.SettingPath, FileMode.Create, FileAccess.ReadWrite);
            WriteSetting(false);
            //try
            //{
            //    fileStream = File.Create(PathManager.SettingPath);
            //}
            //catch
            //{
            //    WriteSetting(false);
            //}
            //fileStream.Close();
            return setting;
        }
        StreamReader sr = null;
        //Setting setting;
=======
            fileStream = new FileStream(GlobalManager.PathName.SettingPath, FileMode.Open,FileAccess.ReadWrite);
        }
        catch
        {
            WriteSetting(false);
            return setting;
        }
        StreamReader sr = null;
>>>>>>> new
        string settingStr ="";
        try
        {
            sr = new StreamReader(fileStream);
        }
        catch
        {
            return null;
        }
<<<<<<< HEAD
        //string line;
        //while ((line = sr.ReadLine()) != null)
        //{
        //    settingStr += line;
        //}
        settingStr = sr.ReadLine();
        //System.Type.GetType("Setting")
        setting = JsonUtility.FromJson<Setting>(settingStr);
        //if (setting == null)
        //{

        //}
        sr.Close();
        //sr.Dispose();
=======

        settingStr = sr.ReadLine();
        setting = JsonUtility.FromJson<Setting>(settingStr);
        sr.Close();
>>>>>>> new
        fileStream.Close();
        return setting;
    }

    public void WriteSetting(bool isTruncate = true)
    {
        try
        {
            if (isTruncate)
            {
<<<<<<< HEAD
                fileStream = new FileStream(GloabalManager.PathNameManager.SettingPath, FileMode.Truncate, FileAccess.Write);
            }
            else
            {
                fileStream = new FileStream(GloabalManager.PathNameManager.SettingPath, FileMode.Create, FileAccess.Write);
=======
                fileStream = new FileStream(GlobalManager.PathName.SettingPath, FileMode.Truncate, FileAccess.Write);
            }
            else
            {
                fileStream = new FileStream(GlobalManager.PathName.SettingPath, FileMode.Create, FileAccess.Write);
>>>>>>> new
            }
        }
        catch
        {
            return;
        }
        StreamWriter sw = null;
        string settingText;
        try
        {
            sw = new StreamWriter(fileStream);
        }
        catch
        {
            return;
        }
        settingText = JsonUtility.ToJson(setting);

        sw.WriteLine(settingText);
        Debug.Log(settingText);
<<<<<<< HEAD
        //sw.Write(settingText.ToCharArray());
        sw.Flush();
        sw.Close();
        fileStream.Close();
        //sw.Dispose();
=======
        sw.Flush();
        sw.Close();
        fileStream.Close();
>>>>>>> new
    }
}

