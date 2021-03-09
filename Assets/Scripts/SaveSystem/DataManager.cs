using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string path;
    
    private void Awake()
    {
        path = Application.persistentDataPath;
    }
    public string GetSaveFilePath(string fileName)
    {
        return path + "/" + fileName + ".json";
    }
}
