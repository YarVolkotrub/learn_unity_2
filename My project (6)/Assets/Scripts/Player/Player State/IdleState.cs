public class IdleState : IState
{
    private PlayerAnimation _animator;

    public IdleState(PlayerAnimation animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.Idle();
    }

    public void Update() {}

    public void Exit() {}
}