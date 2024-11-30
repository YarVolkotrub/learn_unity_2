using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    private Vector2 _moveDirection;

    public PlayerRunState(PlayerAnimation playerAnimation, Mover mover, PlayerPhysics playerPhysics, PlayerStateMachine stateMachine, InputSystem inputSystem) 
        : base(playerAnimation, mover, playerPhysics, stateMachine, inputSystem) { }

    public override void Enter()
    {
        PlayerAnimation.Move();
    }

    public override void Update() 
    {
        _moveDirection = InputSystem.MoveDirection;

        if ((InputSystem.IsStay || _moveDirection == Vector2.zero) && PlayerPhysics.IsRestUpDown)
        {
            StateMachine.SwitchState<PlayerIdleState>();
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

    public override void FixedUpdate() 
    {
        Move(_moveDirection, PlayerPhysics.RunSpeed);
    }

    public override void Exit() { }
}