using UnityEngine;

public class EnemyReturnStartPointState : EnemyBaseState
{
    public EnemyReturnStartPointState(EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {

    }

    public override void Update()
    {

    }

    public override void FixedUpdate() { }

    public override void Exit() { }
}