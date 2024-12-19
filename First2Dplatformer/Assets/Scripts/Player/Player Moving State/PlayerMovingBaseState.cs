using UnityEngine;

public abstract class PlayerMovingBaseState : IState
{
    protected PlayerAnimation PlayerAnimation;
    protected IMover Mover;
    protected PlayerPhysics PlayerPhysics;
    protected IStateSwitcher StateMachine;
    protected IInputSystem InputSystem;

    public PlayerMovingBaseState(PlayerAnimation playerAnimation, IMover mover, PlayerPhysics playerPhysics, IStateSwitcher stateMachine, IInputSystem inputSystem)
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
    public virtual void Exit() {}

    protected virtual void Move(Vector2 moveDirection, float speedMove)
    {
        Mover.Flip(moveDirection);
        Mover.Move(moveDirection.x, speedMove, PlayerPhysics.RigidbodyPlayer.velocity.y);
    }
}