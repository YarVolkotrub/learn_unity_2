using UnityEngine;

public class PlayerInventory : IPlayerInventory
{
    [SerializeField] private int _points = 0;

    public void AddPoints(int points)
    {
        _points += points;
    }
}