using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 5f;
    private Vector3 _directionMovement;
    private GameObject _target;

    private void Update()
    {
        Movement();
    }

    public void Init(Vector3 startPosition, GameObject target)
    {
        transform.position = startPosition;
        _target = target;
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, _target.transform.position, Time.deltaTime * _speed);
    }
}
