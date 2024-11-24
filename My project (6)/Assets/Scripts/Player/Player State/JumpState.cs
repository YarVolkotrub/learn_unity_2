using UnityEngine;

public class JumpState : IState
{
    private PlayerAnimation _animator;
    private Rigidbody2D _rigidbody;
    private float _jumpForce;

    public JumpState(PlayerAnimation animator, Rigidbody2D playerPhysics, float jumpForce)
    {
        _animator = animator;
        _rigidbody = playerPhysics;
        _jumpForce = jumpForce;
    }

    public void Enter()
    {
        _animator.Jump();
    }

    public void Update(){}

    public void Exit(){}
}