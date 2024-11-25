public class FallState : State
{

    public FallState(PlayerAnimation playerAnimation, Mover mover) : base(playerAnimation, mover)
    {
    }

    public void Enter()
    {
        PlayerAnimation.Fall();
    }

    public void Update() {}

    public void Exit() {}
}