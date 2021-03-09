using UnityEngine;
using System;
using System.IO;

public class PointSystem : MonoBehaviour
{
    private PointsData _points;
    private bool _setup = false;

    private DataManager _manager;
    private ReadData _load;
    private WriteData _save;

    private void Start()
    {
        _manager = FindObjectOfType<DataManager>();
        _load = FindObjectOfType<ReadData>();
        _save = FindObjectOfType<WriteData>();

        if(!File.Exists(_manager.GetSaveFilePath("points")))
        {
            // create points json
            _points = new PointsData();
            _save.Save<PointsData>(_points, "points");
        } else
        {
            _points = (PointsData) _load.Load<PointsData>("points");
        }
    }

    public bool CanBuy(int price)
    {
        if (Get() - price >= 0) return true;
        return false;
    }

    public int Get()
    {
        return _points.currentPoints;
    }

    public void Add(int amount)
    {
        _points.AddPoints(amount);
        UpdateAmount();
    }

    public void Subtract(int amount)
    {
        _points.SubtractPoints(amount);
        UpdateAmount();
    }

    private void UpdateAmount()
    {
        Debug.Log("Updated points");
        _save.Save<PointsData>(_points, "points");
    }

}
