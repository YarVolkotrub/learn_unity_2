public abstract class State : IState
{
    protected PlayerAnimation PlayerAnimation;
    protected Mover Mover;

    public State(PlayerAnimation playerAnimation, Mover mover)
    {
        this.PlayerAnimation = playerAnimation;
        this.Mover = mover;
    }

    public void Enter() { }
    public void Update() { }
    public void Exit() { }
}