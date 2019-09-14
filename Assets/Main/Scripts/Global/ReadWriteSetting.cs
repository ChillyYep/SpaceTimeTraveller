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
            fileStream = new FileStream(GlobalManager.PathName.SettingPath, FileMode.Open,FileAccess.ReadWrite);
        }
        catch
        {
            WriteSetting(false);
            return setting;
        }
        StreamReader sr = null;
        string settingStr ="";
        try
        {
            sr = new StreamReader(fileStream);
        }
        catch
        {
            return null;
        }

        settingStr = sr.ReadLine();
        setting = JsonUtility.FromJson<Setting>(settingStr);
        sr.Close();
        fileStream.Close();
        return setting;
    }

    public void WriteSetting(bool isTruncate = true)
    {
        try
        {
            if (isTruncate)
            {
                fileStream = new FileStream(GlobalManager.PathName.SettingPath, FileMode.Truncate, FileAccess.Write);
            }
            else
            {
                fileStream = new FileStream(GlobalManager.PathName.SettingPath, FileMode.Create, FileAccess.Write);
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
        sw.Flush();
        sw.Close();
        fileStream.Close();
    }
}

