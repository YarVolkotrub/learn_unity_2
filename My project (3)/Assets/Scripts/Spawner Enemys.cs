using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemys : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition = new Vector3(0, 1, 0); 
    [SerializeField] private Enemy _prefab;
    [SerializeField] private GameObject _enemyTarget;

    private List<Vector3> _startPositions = new List<Vector3>();
    private float _delay = 2f;
    private Vector3 _directionMovement = Vector3.forward;


    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new(_delay);

        while (true)
        {
            Enemy enemy = Instantiate(_prefab);
            enemy.Init(_startPosition, _enemyTarget);

            yield return wait;
        }
    }
}
