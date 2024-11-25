public class RunState : State
{
    public RunState(PlayerAnimation playerAnimation, Mover mover) : base(playerAnimation, mover)
    {

    }

    public void Enter()
    {
        PlayerAnimation.Move();
    }

    public void Update() {}

    public void Exit() {}
}