using UnityEngine;

public abstract class EnemyBaseState : IState
{
    protected EnemyView View;
    protected EnemyAnimation EnemyAnimation;
    protected EnemyMover Mover;
    protected EnemyStateMachine EnemyStateMachine;
    protected Enemy Enemy;

    public EnemyBaseState(EnemyView view, EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy)
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
    public abstract void Exit();

}