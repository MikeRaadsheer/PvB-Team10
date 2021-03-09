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
        // To Reset all data place this script on the same object as the data manager and Read/Write script.

        // !READ WARNING BEFORE USE!
        if (!File.Exists(_manager.GetSaveFilePath("items"))) SetupData();
        // Un-comment this line of code to completely reset all data.
        // this means all points and hats. any new items that are not
        // in this list will also be removed as a result of running
        // this code please be very cautious!
    }

    public void SetupData()
    {
        // Using a getter instead of find to het plevent accidental reset.
        _load = GetComponent<ReadData>();
        _save = GetComponent<WriteData>();

        PointsData points = new PointsData();
        Items items = new Items();

        ////<<<<<<<<<<<<<< for loop, list of all shop items
        for(int i = 0; i < _hats.Count; i++)
        {
            _hats[i].bought = false;
            items.AddHat(new Item(_hats[i].hatName, _hats[i].price, _hats[i].bought));
        }
        
        /*
        items.AddHat(new Item("Top Hat", 420, false));
        items.AddHat(new Item("Propellor Hat", 69, false));
        items.AddHat(new Item("Flower Hat", 120, false));
        items.AddHat(new Item("Apple Hat", 200, false));
        items.AddHat(new Item("Default Hat", 0, true));
        */

        _save.Save<PointsData>(points, "points"); // Save Points
        _save.Save<Items>(items, "items");        // Save Items
    }
}
