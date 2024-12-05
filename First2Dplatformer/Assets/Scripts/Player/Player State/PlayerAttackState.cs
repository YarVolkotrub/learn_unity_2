using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttackState : PlayerBaseState
{
    private Vector2 _moveDirection;

    public PlayerAttackState(PlayerAnimation playerAnimation, PlayerMover mover, PlayerPhysics playerPhysics, PlayerStateMachine stateMachine, InputSystem inputSystem) 
        : base(playerAnimation, mover, playerPhysics, stateMachine, inputSystem) { }

    public override void Enter()
    {
        PlayerAnimation.Attack();
    }

    public override void Update() 
    {
        //_moveDirection = InputSystem.MoveDirection;

        //if ((InputSystem.IsStay || _moveDirection == Vector2.zero) && PlayerPhysics.IsRestUpDown)
        //{
        //    StateMachine.SwitchState<PlayerIdleState>();
        //}
    }

    public override void FixedUpdate() { }
}