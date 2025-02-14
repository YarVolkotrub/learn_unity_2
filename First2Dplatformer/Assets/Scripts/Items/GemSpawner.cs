using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolGem))]
public class GemSpawner : MonoBehaviour
{
    [SerializeField] private PooledGem _item;
    [SerializeField, Range(0, 10)] private float _sizeSpawner = 8;
    [SerializeField, Range(0, 5)] private float _delaySpawn = 2;
    [SerializeField] private PoolGem _pool;

    private float _spawnAreaSizeMin;
    private float _spawnAreaSizeMax;

    public void Initialization()
    {
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

            PooledGem item = _pool.Get();
            item.LifeTimeIsOver += ReturnItemInPool;
            item.transform.position = new Vector2(GetPointSpawn(), transform.position.y);
        }
    }

    private float GetPointSpawn()
    {
        return Random.Range(_spawnAreaSizeMin, _spawnAreaSizeMax);
    }

    private void ReturnItemInPool(PooledGem item)
    {
        _pool.Return(item);
        item.LifeTimeIsOver -= ReturnItemInPool;
    }
}