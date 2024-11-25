using UnityEngine;

public class Mover
{
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private float _currentPosition;
    private float _rightDirection;
    private float _leftDirection;

    public Mover(Rigidbody2D rigidbody, Transform transform)
    {
        _rigidbody = rigidbody;
        _transform = transform;
        _currentPosition = 0;
        _rightDirection = 180;
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

    public void Flip(float direction)
    {
        if (_currentPosition == direction)
        {
            return;
        }

        Vector2 rotate = _transform.eulerAngles;

        if (_currentPosition > direction)
        {
            rotate.y = _rightDirection;
        }
        else if (_currentPosition < direction)
        {
            rotate.y = _leftDirection;
        }

        _transform.rotation = Quaternion.Euler(rotate);
    }
}
