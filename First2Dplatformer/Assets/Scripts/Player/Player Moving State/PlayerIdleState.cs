using UnityEngine;

public class PlayerIdleState : PlayerMovingBaseState
{
    float _moveDirection;
    public PlayerIdleState(PlayerAnimation playerAnimation, IMover mover, PlayerPhysics playerPhysics, IStateSwitcher stateMachine, IInputSystem inputSystem) 
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
        else if (InputSystem.JumpDirection != Vector2.zero && PlayerPhysics.OnGround)
        {
            StateMachine.SwitchState<PlayerJumpState>();
        }
        else if(PlayerPhysics.OnGround == false && PlayerPhysics.IsFalling)
        {
            StateMachine.SwitchState<PlayerFallState>();
        }
        else if(InputSystem.IsMeleeAttack && PlayerPhysics.OnGround)
        {
            StateMachine.SwitchState<PlayerMeleeAttackState>();
        }
    }

    public override void FixedUpdate() { }
}