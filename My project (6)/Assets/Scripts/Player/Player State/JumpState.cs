using UnityEngine;

public class JumpState : State
{
    public JumpState(PlayerAnimation playerAnimation, Mover mover) : base(playerAnimation, mover)
    {
    }

    public void Enter()
    {
        PlayerAnimation.Jump();
    }

    public void Update() {}

    public void Exit() {}
}