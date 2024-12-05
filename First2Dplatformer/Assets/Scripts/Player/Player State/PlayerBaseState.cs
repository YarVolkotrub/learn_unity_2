using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerAnimation PlayerAnimation;
    protected PlayerMover Mover;
    protected PlayerPhysics PlayerPhysics;
    protected PlayerStateMachine StateMachine;
    protected InputSystem InputSystem;

    public PlayerBaseState(PlayerAnimation playerAnimation, PlayerMover mover, PlayerPhysics playerPhysics, PlayerStateMachine stateMachine, InputSystem inputSystem)
    {
        PlayerAnimation = playerAnimation;
        Mover = mover;
        PlayerPhysics = playerPhysics;
        StateMachine = stateMachine;
        InputSystem = inputSystem;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public virtual void Exit() { }

    protected virtual void Move(Vector2 moveDirection, float speedMove)
    {
        Mover.Flip(moveDirection);
        Mover.Move(moveDirection.x, speedMove, PlayerPhysics.RigidbodyPlayer.velocity.y);
    }
}