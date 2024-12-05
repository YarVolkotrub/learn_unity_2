using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    float _moveDirection;
    public PlayerIdleState(PlayerAnimation playerAnimation, PlayerMover mover, PlayerPhysics playerPhysics, PlayerStateMachine stateMachine, InputSystem inputSystem) 
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

        if (InputSystem.IsAttack)
        {
            StateMachine.SwitchState<PlayerAttackState>();
        }
    }

    public override void FixedUpdate() { }
}