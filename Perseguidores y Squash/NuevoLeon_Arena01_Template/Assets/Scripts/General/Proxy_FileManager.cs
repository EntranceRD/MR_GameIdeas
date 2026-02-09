using Entrance.General;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proxy_FileManager : MonoBehaviour
{
    public Proxy_FileManager()
    {
        File = new FileSystem(Application.streamingAssetsPath);
    }

    private void Awake()
    {
        File.FileToObjectConversion += (contents, type) =>
        {
            return JsonUtility.FromJson(contents, type);
        };
        File.ObjectToFileConversion += (obj) =>
        {
            return JsonUtility.ToJson(obj);
        };
        FileSystem.Instance = File;
    }

    private FileSystem File;

}
