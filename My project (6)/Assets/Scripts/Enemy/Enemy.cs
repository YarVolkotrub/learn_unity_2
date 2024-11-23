using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedMove = 2f;
    [SerializeField] private EnemyPatrol _patrol;
    [SerializeField] private float _delay = 5f;
    [SerializeField] private Vector2 _pointForPatrol;

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        _patrol.Move(_pointForPatrol, _speedMove, _delay);
    }
}