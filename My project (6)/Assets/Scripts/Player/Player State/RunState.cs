public class RunState : IState
{
    private PlayerAnimation _animator;

    public RunState(PlayerAnimation animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.Move();
    }

    public void Update() {}

    public void Exit() {}
}