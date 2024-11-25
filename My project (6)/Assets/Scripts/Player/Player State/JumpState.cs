using UnityEngine;

public class JumpState : IState
{
    private PlayerAnimation _animator;

    public JumpState(PlayerAnimation animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.Jump();
    }

    public void Update() {}

    public void Exit() {}
}