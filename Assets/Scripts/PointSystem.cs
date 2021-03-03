using UnityEngine;

public static class PointSystem
{
    private static int _points;

    public static int Get()
    {
        if(_points == null)
        {
            _points = PlayerPrefs.GetInt("Points");
            return _points;
        }
        return _points;
    }

    public static void Add(int amount)
    {
        _points += amount;
    }

    public static void Set(int value)
    {
        _points = value;
        UpdateAmount(_points);
    }


    private static void UpdateAmount()
    {
        PlayerPrefs.SetInt("Points", _points);
    }

}
