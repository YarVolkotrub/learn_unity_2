using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private Vector2 _moveDirection;
    private float _timer;

    public PlayerFallState(IPlayerAnimator playerAnimation, IMover mover, PlayerPhysics playerPhysics, IStateSwitcher stateMachine, IInputSystem inputSystem) 
        : base(playerAnimation, mover, playerPhysics, stateMachine, inputSystem) { }

    public override void Enter()
    {
        PlayerAnimation.Fall();
        _timer = 0;
    }

    public override void Update() 
    {
        _moveDirection = InputSystem.MoveDirection;

        if (PlayerPhysics.OnGround)
        {
            StateMachine.SwitchState<PlayerIdleState>();
        }
        else if (PlayerPhysics.IsDoubleJump && InputSystem.JumpDirection == Vector2.up && _timer >= PlayerPhysics.DelayDoubleJump)
        {
            PlayerPhysics.DisableDoubleJump();
            StateMachine.SwitchState<PlayerJumpState>();
        }

        _timer += Time.deltaTime;
    }

    public override void FixedUpdate()
    {
        Move(_moveDirection, PlayerPhysics.FallMoveSpeed);
    }
}