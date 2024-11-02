using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemys : MonoBehaviour
{
    [SerializeField] private Vector3 _positionOne = new Vector3(0, 1, 0);
    [SerializeField] private Vector3 _positionTwo = new Vector3(5, 1, 0);
    [SerializeField] private Vector3 _positionThree = new Vector3(10, 1, 0);
    [SerializeField] private Enemy _prefab;

    private List<Vector3> _startPositions = new List<Vector3>();
    private float _delay = 2f;
    private Vector3 _directionMovement = Vector3.forward;

    private void Awake()
    {
        _startPositions.Add(_positionOne);
        _startPositions.Add(_positionTwo);
        _startPositions.Add(_positionThree);
    }
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
            Vector3 startPosition = GetStartPosition();
            enemy.Init(startPosition, _directionMovement);

            yield return wait;
        }
    }

    private Vector3 GetStartPosition()
    {
        return _startPositions[Random.Range(0, _startPositions.Count)];
    }
}
