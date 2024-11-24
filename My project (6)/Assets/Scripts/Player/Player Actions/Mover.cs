using UnityEngine;

public abstract class Mover
{
    protected Rigidbody2D Rigidbody;
    protected Vector2 Direction;
    protected float MoveSpeed;
    protected float JumpForce;
    protected float JumpSpeed;
}
