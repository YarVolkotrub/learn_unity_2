using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private Vector2 _moveDirection;
    public PlayerJumpState(PlayerAnimation playerAnimation, Mover mover, PlayerPhysics playerPhysics, PlayerStateMachine stateMachine, InputSystem inputSystem) 
        : base(playerAnimation, mover, playerPhysics, stateMachine, inputSystem) { }

    public override void Enter()
    {
        Mover.Jump(PlayerPhysics.RigidbodyPlayer.velocity.x, PlayerPhysics.JumpForce);
        PlayerAnimation.Jump();
    }

    public override void Update() 
    {
        _moveDirection = InputSystem.MoveDirection;

        if (PlayerPhysics.IsFalling)
        {
            StateMachine.SwitchState<PlayerFallState>();
        }

        if (PlayerPhysics.OnGround && PlayerPhysics.IsJumping == false)
        {
            StateMachine.SwitchState<PlayerIdleState>();
        }
    }

    public override void FixedUpdate()
    {
        Move(_moveDirection, PlayerPhysics.JumpMoveSpeed);
    }

    public override void Exit() { }
}