using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ItemPool))]
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private ItemFromPool _item;
    [SerializeField] private float _sizeSpawner;
    [SerializeField] private float _delaySpawn = 2;
    private ItemPool _pool;

    private float _spawnAreaSizeMin;
    private float _spawnAreaSizeMax;

    public void Init()
    {
        _pool = GetComponent<ItemPool>();
        _spawnAreaSizeMin = transform.position.x - _sizeSpawner;
        _spawnAreaSizeMax = transform.position.x + _sizeSpawner;
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new(_delaySpawn); 

        while (true)
        {
            yield return wait;

            ItemFromPool item = _pool.Get();
            item.LifeTimeIsOver += ReturnItemInPool;
            item.transform.position = new Vector2(GetPointSpawn(), transform.position.y);
        }
    }

    private float GetPointSpawn()
    {
        return Random.Range(_spawnAreaSizeMin, _spawnAreaSizeMax);
    }

    private void ReturnItemInPool(ItemFromPool item)
    {
        _pool.Return(item);
        item.LifeTimeIsOver -= ReturnItemInPool;
    }
}