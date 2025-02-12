using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour 
{
    [SerializeField] private GemInPool _item;
    [SerializeField, Range(1, 5)] private int _capacity = 5;
    [SerializeField, Range(1, 5)] private int _itemLife = 3;
    private Queue<GemInPool> _items = new();

    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            _items.Enqueue(Instantiate(_item));
        }

        foreach(GemInPool item in _items)
        {
            item.gameObject.SetActive(false);
            item.Init(_itemLife);
        }
    }

    public GemInPool Get()
    {
        if (_items.Count == 0)
        {
            ExpandPool();
        }

        GemInPool newItem = _items.Dequeue();
        newItem.gameObject.SetActive(true);

        return newItem;
    }

    public void Return(GemInPool item)
    {
        item.gameObject.SetActive(false);
        _items.Enqueue(item);
    }

    private void ExpandPool()
    {
        GemInPool item = Instantiate(_item);
        item.Init(_itemLife);
        _items.Enqueue(item);
    }
}