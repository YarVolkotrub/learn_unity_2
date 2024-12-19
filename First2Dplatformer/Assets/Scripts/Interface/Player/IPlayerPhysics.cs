using UnityEngine;

public interface IPlayerPhysics
{
    public float DelayDoubleJump { get; }
    public Rigidbody2D RigidbodyPlayer { get; }
    public bool IsDoubleJump { get; }
    public float RunSpeed { get; }
    public float JumpForce { get; }
    public float JumpMoveSpeed { get; }
    public float FallMoveSpeed { get; }
    public bool IsFalling { get; }
    public bool IsJumping { get; }
    public bool IsRestUpDown { get; }

    public void ActiveDoubleJump();

    public void DisableDoubleJump();
}