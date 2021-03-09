using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllData : MonoBehaviour
{
    DataManager _manager;
    ReadData _load;
    WriteData _save;

    private void Start()
    {
        // To Reset all data place this script on the same object as the data manager and Read/Write script.

        // !READ WARNING BEFORE USE!
        ResetData();
        // Un-comment this line of code to completely reset all data.
        // this means all points and hats. any new items that are not
        // in this list will also be removed as a result of running
        // this code please be very cautious!
    }

    public void ResetData()
    {
        // Using a getter instead of find to het plevent accidental reset.
        _manager = GetComponent<DataManager>();
        _load = GetComponent<ReadData>();
        _save = GetComponent<WriteData>();

        PointsData points = new PointsData();
        Items items = new Items();

        items.AddHat(new Item("Top Hat", 420, false));
        items.AddHat(new Item("Propellor Hat", 69, false));
        items.AddHat(new Item("Flower Hat", 120, false));
        items.AddHat(new Item("Apple Hat", 200, false));
        items.AddHat(new Item("Default Hat", 0, true));

        _save.Save<PointsData>(points, "points"); // Save Points
        _save.Save<Items>(items, "items");        // Save Items
    }
}
