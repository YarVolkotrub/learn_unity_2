using System.Collections;
using UnityEngine;

public class SpawnerEnemysTypeTwo : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition = new Vector3(0, 1, 0);
    [SerializeField] private EnemyTypeTwo _prefab;
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
            EnemyTypeTwo enemy = Instantiate(_prefab);
            enemy.Init(_startPosition, _enemyTarget);

            yield return wait;
        }
    }
}
