public abstract class EnemyBaseState : IState
{
    protected IVisionEnemy View;
    protected IEnemyAnimator EnemyAnimation;
    protected IEnemyMover Mover;
    protected IStateSwitcher EnemyStateMachine;
    protected Enemy Enemy;

    public EnemyBaseState(IVisionEnemy view, IEnemyAnimator enemyAnimation, IEnemyMover mover, IStateSwitcher stateMachine, Enemy enemy)
    {
        View = view;
        EnemyAnimation = enemyAnimation;
        Mover = mover;
        EnemyStateMachine = stateMachine;
        Enemy = enemy;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}