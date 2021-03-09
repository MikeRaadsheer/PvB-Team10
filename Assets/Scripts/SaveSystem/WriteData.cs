using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteData : MonoBehaviour
{
    private DataManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<DataManager>();
    }

    public void Save<T>(T data, string fileName)
    {
        string path = _manager.GetSaveFilePath(fileName);
        string JsonObj = JsonUtility.ToJson(data);

        File.WriteAllText(path, JsonObj);

        //Debug.Log("Saved File: " + fileName);
    }
}
