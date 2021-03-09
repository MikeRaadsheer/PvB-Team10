using UnityEngine;
using System;

public static class PointSystem
{
    private static int _points;
    private static bool _setup = false;



    public static bool CanBuy(int price)
    {
        if (Get() - price >= 0) return true;
        return false;
    }

    public static int Get()
    {
        if(!_setup)
        {
            try
            {
                _points = PlayerPrefs.GetInt("Points");
                return _points;
            } catch/*(Exception e)*/
            {
                _points = 0;
                UpdateAmount();
                return _points;
                //throw new Exception($"Could not obtain points. \n{e.Message}");
            }
        }
        return _points;
    }

    public static void Add(int amount)
    {
        _points += amount;
        UpdateAmount();
    }

    public static void Subtract(int amount)
    {
        _points -= amount;
        UpdateAmount();
    }

    public static void Set(int value)
    {
        _points = value;
        UpdateAmount();
    }

    private static void UpdateAmount()
    {
        PlayerPrefs.SetInt("Points", _points);
    }

}
