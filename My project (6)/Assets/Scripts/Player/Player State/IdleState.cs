public class IdleState : State
{
    public IdleState(PlayerAnimation playerAnimation, Mover mover) : base(playerAnimation, mover)
    {

    }

    public void Enter()
    {
        PlayerAnimation.Idle();
    }

    public void Update() {}

    public void Exit() {}
}