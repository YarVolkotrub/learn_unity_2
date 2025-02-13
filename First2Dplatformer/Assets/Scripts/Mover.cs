using UnityEngine;

public class Mover
{
    protected Rigidbody2D _rigidbody;
    protected Transform _transform;
    protected float _currentPosition;
    protected float _rightDirection;
    protected float _leftDirection;

    public Mover(Rigidbody2D rigidbody, Transform transform)
    {
        _rigidbody = rigidbody;
        _transform = transform;
        _currentPosition = 0;
        _rightDirection = -180;
        _leftDirection = 0;
    }

    public virtual void Stand()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    public virtual void Flip(Vector2 direction)
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