using System.Collections.Generic;
using UnityEngine;

public class PoolGem : MonoBehaviour 
{
    [SerializeField] private PooledGem _item;
    [SerializeField, Range(1, 5)] private int _capacity = 5;
    [SerializeField, Range(1, 5)] private int _itemLife = 3;
    private Queue<PooledGem> _items = new();

    private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            _items.Enqueue(Instantiate(_item));
        }

        foreach(PooledGem item in _items)
        {
            item.gameObject.SetActive(false);
            item.Init(_itemLife);
        }
    }

    public PooledGem Get()
    {
        if (_items.Count == 0)
        {
            ExpandPool();
        }

        PooledGem newItem = _items.Dequeue();
        newItem.gameObject.SetActive(true);

        return newItem;
    }

    public void Return(PooledGem item)
    {
        item.gameObject.SetActive(false);
        _items.Enqueue(item);
    }

    private void ExpandPool()
    {
        PooledGem item = Instantiate(_item);
        item.Init(_itemLife);
        _items.Enqueue(item);
    }
}