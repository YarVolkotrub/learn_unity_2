using System;
using System.Collections;
using System.Net;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimation))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _animation;
    private float _endPoint = 0f;
    private Vector2[] _pointPatrol;
    private Vector2 _startPosition;

    public event Action<float> Rotation;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void Move(Vector2 endPosition, float speedMove, float wait)
    {
        float direction = transform.position.x - endPosition.x;
        Rotation?.Invoke(direction);

        _animation.Move();
        transform.position = Vector2.MoveTowards(transform.position, endPosition, speedMove * Time.deltaTime);


        if (Vector2.Distance(transform.position, endPosition) <= _endPoint)
        {
            _animation.Idle();
            StartCoroutine(Inspection(wait));

            ReturnBack(speedMove, wait);
        }
    }

    private void ReturnBack(float speedMove, float wait)
    {
        Move(_startPosition, speedMove, wait);
    }

    private IEnumerator Inspection(float delay)
    {
        WaitForSeconds wait = new(delay);


        yield return wait;
    }
}