using System;

[Serializable]
public class PointsData
{
    public int currentPoints = 0; // the points a player actually has
    public int totalPoints = 0;   // the amount of points the player earned over the entire game

    public void AddPoints(int amount)
    {
        totalPoints += amount;
        currentPoints += amount;
    }

    public void SubtractPoints(int amount)
    {
        currentPoints -= amount;
    }

}
