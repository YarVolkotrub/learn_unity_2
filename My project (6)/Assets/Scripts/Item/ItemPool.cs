using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour 
{
    [SerializeField] private Item _item;
    [SerializeField] private int _capacity = 5;
    [SerializeField] private int _itemLife = 3;
    private Queue<Item> _items = new();

    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            _items.Enqueue(Instantiate(_item));
        }

        foreach(Item item in _items)
        {
            item.gameObject.SetActive(false);
            item.Init(this, _itemLife);
        }
    }

    public Item Get()
    {
        if (_items.Count == 0)
        {
            ExpandPool();
        }

        Item newItem = _items.Dequeue();
        newItem.gameObject.SetActive(true);

        return newItem;
    }

    public void Return(Item item)
    {
        item.gameObject.SetActive(false);
        _items.Enqueue(item);
    }

    private void ExpandPool()
    {
        Item item = Instantiate(_item);
        item.Init(this, _itemLife);
        _items.Enqueue(item);
    }
}