using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    private Vector2 _moveDirection;

    public PlayerRunState(IPlayerAnimator playerAnimation, IMover mover, PlayerPhysics playerPhysics, IStateSwitcher stateMachine, IInputSystem inputSystem) 
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
        else if (InputSystem.JumpDirection != Vector2.zero && PlayerPhysics.OnGround)
        {
            StateMachine.SwitchState<PlayerJumpState>();
        }
        else if (PlayerPhysics.OnGround == false && PlayerPhysics.IsFalling)
        {
            StateMachine.SwitchState<PlayerFallState>();
        }
        else if (InputSystem.IsMeleeAttack && PlayerPhysics.OnGround)
        {
            StateMachine.SwitchState<PlayerMeleeAttackState>();
        }
    }

    public override void FixedUpdate() 
    {
        Move(_moveDirection, PlayerPhysics.RunSpeed);
    }
}