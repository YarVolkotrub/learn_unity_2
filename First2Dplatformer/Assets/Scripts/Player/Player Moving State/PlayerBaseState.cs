using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected IPlayerAnimator PlayerAnimation;
    protected IMover Mover;
    protected PlayerPhysics PlayerPhysics;
    protected IStateSwitcher StateMachine;
    protected IInputSystem InputSystem;

    public PlayerBaseState(IPlayerAnimator playerAnimation, IMover mover, PlayerPhysics playerPhysics, IStateSwitcher stateMachine, IInputSystem inputSystem)
    {
        PlayerAnimation = playerAnimation;
        Mover = mover;
        PlayerPhysics = playerPhysics;
        StateMachine = stateMachine;
        InputSystem = inputSystem;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }

    protected virtual void Move(Vector2 moveDirection, float speedMove)
    {
        Mover.Flip(moveDirection);
        Mover.Move(moveDirection.x, speedMove, PlayerPhysics.RigidbodyPlayer.velocity.y);
    }
}