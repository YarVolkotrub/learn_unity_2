using UnityEngine;

public class EnemyMover: IEnemyMover
{
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private float _currentPosition;
    private float _rightDirection;
    private float _leftDirection;

    public EnemyMover(Rigidbody2D rigidbody, Transform transform)
    {
        _rigidbody = rigidbody;
        _transform = transform;
        _currentPosition = 0;
        _rightDirection = -180;
        _leftDirection = 0;
    }

    public void Move(Vector2 targetPosition, float speed)
    {
        _transform.position = Vector2.MoveTowards(_transform.position, targetPosition, speed * Time.fixedDeltaTime);
    }

    public void Stand()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    public bool IsEndPoint(Vector2 targetPosition, float minDistanceForTarget)
    {
        return Vector2.Distance(_transform.position, targetPosition) < minDistanceForTarget;
    }

    public Vector2 SetDirection(float targetPosition)
    {
        if (_transform.position.x < targetPosition)
        {
            return Vector2.right;
        }

        return Vector2.left;
    }

    public void Flip(Vector2 direction)
    {
        if (_currentPosition == direction.x)
        {
            return;
        }

        Vector2 rotate = _transform.eulerAngles;

        if (_currentPosition > direction.x)
        {
            rotate.y = _rightDirection;
        }
        else if (_currentPosition < direction.x)
        {
            rotate.y = _leftDirection;
        }

        _transform.rotation = Quaternion.Euler(rotate);
    }
}