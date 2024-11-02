using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4f;
    private Vector3 _directionMovement;
    private void Update()
    {
        Movement();
    }

    public void Init(Vector3 startPosition, Vector3 directionMovement)
    {
        _directionMovement = directionMovement;
        transform.position = startPosition;
    }

    private void Movement()
    {
        transform.Translate(_directionMovement * _speed * Time.deltaTime);
    }
}
