using UnityEngine;

public abstract class PlayerCombatBaseState : IState
{
    protected PlayerAnimation PlayerAnimation;
    protected PlayerMover Mover;
    protected PlayerPhysics PlayerPhysics;
    protected PlayerCombatStateMachine StateMachine;
    protected InputReader InputSystem;

    public PlayerCombatBaseState(PlayerAnimation playerAnimation, PlayerPhysics playerPhysics, InputReader inputSystem, PlayerCombatStateMachine stateMachine)
    {
        PlayerAnimation = playerAnimation;
        PlayerPhysics = playerPhysics;
        InputSystem = inputSystem;
        StateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public virtual void Exit() { }
}