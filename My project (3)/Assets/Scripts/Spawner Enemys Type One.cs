using System.Collections;
using UnityEngine;

public class SpawnerEnemysTypeOne : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition = new Vector3(0, 1, 0); 
    [SerializeField] private EnemyTypeOne _prefab;
    [SerializeField] private Transform _enemyTarget;

    private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new(_delay);

        while (true)
        {
            EnemyTypeOne enemy = Instantiate(_prefab);
            enemy.Init(_startPosition, _enemyTarget);

            yield return wait;
        }
    }
}
