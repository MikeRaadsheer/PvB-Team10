using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;

public class SetUIText : MonoBehaviour
{
    DataManager _manager;
    ReadData _load;
    WriteData _save;

    public TextMeshProUGUI txtObj;

    private void Start()
    {
        _load = FindObjectOfType<ReadData>();
        _save = FindObjectOfType<WriteData>();
        _manager = FindObjectOfType<DataManager>();

        PointsData points = (PointsData)_load.Load<PointsData>("points"); // Load Player Points
        Items items = (Items)_load.Load<Items>("items");                  // Load All Items (Hats and stuff)

        points = new PointsData();

        string itemsTxt = "";
        var topHat = items.GetHat("Top Hat");

        //Debug.Log(topHat.price);

        var hats = items.GetHats();
        Debug.Log(hats.Count);

        for (int i = 0; i < hats.Count; i++)
        {

            itemsTxt += hats[i].name + " | " + hats[i].price + "\n";
            Debug.Log(hats[i].name + " | " + hats[i].price);
            //if (hats[i].name == "topHat")
            //{
                //Debug.Log(hats[i].price);
            //}
        }



        points.AddPoints(34786);
        points.AddPoints(420);
        points.AddPoints(69);
        points.SubtractPoints(9000);

        _save.Save<Items>(items, "items");        // Save Items
        _save.Save<PointsData>(points, "points"); // Save Points

        SetText(txtObj, "Points: " + points.currentPoints.ToString() + "\n" + itemsTxt);
    }

    public void SetText(TextMeshProUGUI text, string value)
    {
        text.text = value;
    }
}
