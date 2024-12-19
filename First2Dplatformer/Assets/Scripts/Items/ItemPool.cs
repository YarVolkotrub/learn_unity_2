using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour 
{
    [SerializeField] private ItemFromPool _item;
    [SerializeField, Range(1, 5)] private int _capacity = 5;
    [SerializeField, Range(1, 5)] private int _itemLife = 3;
    private Queue<ItemFromPool> _items = new();

    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            _items.Enqueue(Instantiate(_item));
        }

        foreach(ItemFromPool item in _items)
        {
            item.gameObject.SetActive(false);
            item.Init(_itemLife);
        }
    }

    public ItemFromPool Get()
    {
        if (_items.Count == 0)
        {
            ExpandPool();
        }

        ItemFromPool newItem = _items.Dequeue();
        newItem.gameObject.SetActive(true);

        return newItem;
    }

    public void Return(ItemFromPool item)
    {
        item.gameObject.SetActive(false);
        _items.Enqueue(item);
    }

    private void ExpandPool()
    {
        ItemFromPool item = Instantiate(_item);
        item.Init(_itemLife);
        _items.Enqueue(item);
    }
}