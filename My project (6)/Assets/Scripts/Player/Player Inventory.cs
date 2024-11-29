using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _points = 0;

    public void AddPoints(Item item)
    {
        _points += item.Cost;
    }
}