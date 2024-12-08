using UnityEngine;

public class PlayerFallState : PlayerMovingBaseState
{
    private Vector2 _moveDirection;
    private float _timer;

    public PlayerFallState(PlayerAnimation playerAnimation, PlayerMover mover, PlayerPhysics playerPhysics, PlayerMovingStateMachine stateMachine, InputReader inputSystem) 
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

        if (PlayerPhysics.IsDoubleJump && InputSystem.JumpDirection == Vector2.up && _timer >= PlayerPhysics.DelayDoubleJump)
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