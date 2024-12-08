using UnityEngine;

public class PlayerIdleState : PlayerMovingBaseState
{
    float _moveDirection;
    public PlayerIdleState(PlayerAnimation playerAnimation, PlayerMover mover, PlayerPhysics playerPhysics, PlayerMovingStateMachine stateMachine, InputReader inputSystem) 
        : base(playerAnimation, mover, playerPhysics, stateMachine, inputSystem) { }

    public override void Enter()
    {
        PlayerPhysics.ActiveDoubleJump();
        Mover.Stand();
        PlayerAnimation.Idle();
    }

    public override void Update() 
    {
        if (InputSystem.MoveDirection != Vector2.zero && PlayerPhysics.OnGround)
        {
            StateMachine.SwitchState<PlayerRunState>();
        }

        if (InputSystem.JumpDirection != Vector2.zero && PlayerPhysics.OnGround)
        {
            StateMachine.SwitchState<PlayerJumpState>();
        }

        if (PlayerPhysics.OnGround == false && PlayerPhysics.IsFalling)
        {
            StateMachine.SwitchState<PlayerFallState>();
        }
    }

    public override void FixedUpdate() { }
}