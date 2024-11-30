using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerAnimation PlayerAnimation;
    protected Mover Mover;
    protected PlayerPhysics PlayerPhysics;
    protected PlayerStateMachine StateMachine;
    protected InputSystem InputSystem;

    public PlayerBaseState(PlayerAnimation playerAnimation, Mover mover, PlayerPhysics playerPhysics, PlayerStateMachine stateMachine, InputSystem inputSystem)
    {
        this.PlayerAnimation = playerAnimation;
        this.Mover = mover;
        this.PlayerPhysics = playerPhysics;
        this.StateMachine = stateMachine;
        this.InputSystem = inputSystem;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();

    protected virtual void Move(Vector2 moveDirection, float speedMove)
    {
        Mover.Flip(moveDirection);
        Mover.Move(moveDirection.x, speedMove, PlayerPhysics.RigidbodyPlayer.velocity.y);
    }
}