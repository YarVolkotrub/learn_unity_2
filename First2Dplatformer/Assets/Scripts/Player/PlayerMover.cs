using UnityEngine;

public class PlayerMover : Mover, IMover
{
    public PlayerMover(Rigidbody2D rigidbody, Transform transform) : base(rigidbody, transform) { }

    public void Move(float directionAxisX , float speed, float directionAxisY)
    {
        _rigidbody.velocity = new Vector2(directionAxisX * speed, directionAxisY);
    }

    public void Jump(float directionAxisY, float speed)
    {
        _rigidbody.velocity = new Vector2(directionAxisY, speed);
    }
}