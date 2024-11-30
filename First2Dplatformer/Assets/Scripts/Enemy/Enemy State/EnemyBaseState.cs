using UnityEngine;

public abstract class EnemyBaseState : IState
{
    protected EnemyAnimation EnemyAnimation;
    protected Mover Mover;
    protected EnemyStateMachine EnemyStateMachine;
    protected Enemy Enemy;

    public EnemyBaseState(EnemyAnimation enemyAnimation, Mover mover, EnemyStateMachine stateMachine, Enemy enemy)
    {
        this.EnemyAnimation = enemyAnimation;
        this.Mover = mover;
        this.EnemyStateMachine = stateMachine;
        this.Enemy = enemy;
    }

    public abstract void Enter(); 
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();

    public virtual void Move(Vector2 direction, float speed)
    {
        Mover.Move(direction.x, speed, Enemy.RigidbodyEnemy.velocity.y);
    }
}