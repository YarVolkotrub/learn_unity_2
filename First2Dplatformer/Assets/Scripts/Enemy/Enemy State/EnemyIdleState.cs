using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private float _timer;

    public EnemyIdleState(EnemyAnimation enemyAnimation, Mover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        _timer = 0;
        EnemyAnimation.Idle();
        Mover.Stand();
    }

    public override void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= Enemy.Wait)
        {
            EnemyStateMachine.SwitchState<EnemyMovingState>();
        }
    }

    public override void FixedUpdate() { }

    public override void Exit() { }
}