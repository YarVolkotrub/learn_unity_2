using UnityEngine;

public abstract class EnemyBaseState : IState
{
    protected EnemyAnimation EnemyAnimation;
    protected EnemyMover Mover;
    protected EnemyStateMachine EnemyStateMachine;
    protected Enemy Enemy;
    protected Vector2 Direction = Vector2.zero;

    public EnemyBaseState(EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy)
    {
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