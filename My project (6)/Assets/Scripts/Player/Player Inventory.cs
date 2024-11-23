using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _money = 0;
    private List<Item> _items = new List<Item>();

    public void AddItem(Item item)
    {
        Item copyItem = new Item();
        _items.Add(copyItem);
        _money += copyItem.Cost;
    }
}