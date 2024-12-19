public abstract class EnemyBaseState : IState
{
    protected IEnemyView View;
    protected IEnemyAnimation EnemyAnimation;
    protected IEnemyMover Mover;
    protected IStateSwitcher EnemyStateMachine;
    protected Enemy Enemy;

    public EnemyBaseState(IEnemyView view, IEnemyAnimation enemyAnimation, IEnemyMover mover, IStateSwitcher stateMachine, Enemy enemy)
    {
        View = view;
        EnemyAnimation = enemyAnimation;
        Mover = mover;
        EnemyStateMachine = stateMachine;
        Enemy = enemy;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public void Exit() { }

}