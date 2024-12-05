using UnityEngine;

public class PlayerMover : IMover
{
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private float _currentPosition;
    private float _rightDirection;
    private float _leftDirection;

    public PlayerMover(Rigidbody2D rigidbody, Transform transform)
    {
        _rigidbody = rigidbody;
        _transform = transform;
        _currentPosition = 0;
        _rightDirection = -180;
        _leftDirection = 0;
    }

    public void Move(float directionAxisX , float speed, float directionAxisY)
    {
        _rigidbody.velocity = new Vector2(directionAxisX * speed, directionAxisY);
    }

    public void Jump(float directionAxisY, float speed)
    {
        _rigidbody.velocity = new Vector2(directionAxisY, speed);
    }

    public void Stand()
    {
        _rigidbody.velocity = Vector2.zero;
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