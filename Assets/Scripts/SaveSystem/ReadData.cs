using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ReadData : MonoBehaviour
{
    private DataManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<DataManager>();
    }


    public object Load<T>(string fileName)
    {
        string path = _manager.GetSaveFilePath(fileName);
        if (File.Exists(path))
        {
            string JsonObj = File.ReadAllText(path);
            T data = JsonUtility.FromJson<T>(JsonObj);

            //Debug.Log("Loaded File: " + fileName);
            return data;
        }
        else
        {
            throw new Exception("Could not find data, please make sure that the specified data exists and that the spelling is correct.");
        }
    }

}
