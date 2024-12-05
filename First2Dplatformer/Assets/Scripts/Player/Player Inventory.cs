using UnityEngine;

public class PlayerInventory
{
    [SerializeField] private int _points = 0;

    public void AddPoints(int points)
    {
        _points += points;
    }
}