using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    Vector2 _moveDirection;
    public EnemyMovingState(EnemyAnimation enemyAnimation, Mover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        EnemyAnimation.Move();

        //if (Enemy.OnGround == false)
        //{
        //    if (Enemy.transform.eulerAngles.y >= 0)
        //    {
        //        _moveDirection = new Vector2(-1, 0);
        //    }
        //    else
        //    {
        //        _moveDirection = new Vector2(1, 0);
        //    }

        //    Mover.Flip(_moveDirection);
        //}
    }

    public override void Update()
    {
        //if (Enemy.OnGround == false)
        //{
        //    EnemyStateMachine.SwitchState<EnemyIdleState>();
        //}
    }

    public override void FixedUpdate() 
    {
        //Enemy.Move();
        //Mover.Flip(moveDirection);
        //Move(_moveDirection, Enemy.Speed);
        //Enemy.RB.velocity = new Vector2(-1 * Enemy.Speed, Enemy.RB.velocity.y);
    }

    public override void Exit() { }
}