using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ReadStory {
    private List<string> storys;
    private static ReadStory instance;
    private ReadStory()
    {
        storys = new List<string>();
    }
    public static ReadStory GetStoryReader()
    {
        if (null == instance)
        {
            instance = new ReadStory();
        }
        return instance;
    }

    public List<string> readFile(string filePath)
    {
        storys.Clear();
        FileStream fileStream = null;
        StreamReader sr = null;
        //Encoding encoding=null;
        try
        {
            fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fileStream,Encoding.Default);
        }
        catch
        {
            return storys;
        }
        //byte[] str;
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            storys.Add(line);
        }
        sr.Close();
        sr.Dispose();
        return storys;
    }
}
