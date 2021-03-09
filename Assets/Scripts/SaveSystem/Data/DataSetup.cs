using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSetup : MonoBehaviour
{
    DataManager _manager;
    ReadData _load;
    WriteData _save;

    [SerializeField]
    private List<Shop.Hat> _hats = new List<Shop.Hat>();

    private void Start()
    {
        _manager = GetComponent<DataManager>();
        _load = GetComponent<ReadData>();
        _save = GetComponent<WriteData>();

        if (!File.Exists(_manager.GetSaveFilePath("items"))) SetupItems();
        if (!File.Exists(_manager.GetSaveFilePath("points"))) SetupPoints();
    }

    public void SetupItems()
    {
        Items items = new Items();

        for (int i = 0; i < _hats.Count; i++)
        {
            _hats[i].bought = false;
            items.AddHat(new Item(_hats[i].hatName, _hats[i].price, _hats[i].bought));
        }
        _save.Save<Items>(items, "items");        // Save Items
    }

    public void SetupPoints()
    {
        PointsData points = new PointsData();
        _save.Save<PointsData>(points, "points"); // Save Points
    }
}
