public class FallState : IState
{
    private PlayerAnimation _animator;

    public FallState(PlayerAnimation animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.Fall();
    }

    public void Update() {}

    public void Exit() {}
}