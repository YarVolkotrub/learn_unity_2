using UnityEngine;

public class IdleState : IState
{
    PlayerAnimation animator;

    public IdleState(PlayerAnimation animator)
    {
        this.animator = animator;
    }

    public void Enter()
    {
        animator.Idle();
    }

    public void Update() {}

    public void Exit() {}
}