using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private float _timer;

    public EnemyIdleState(EnemyView view, EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(view, enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        _timer = 0;
        EnemyAnimation.Idle();
        Mover.Stand();
    }

    public override void Update()
    {
        Debug.DrawRay(Enemy.transform.position, View.Direction * View.Distance, Color.red);

        if (Enemy.OnGround && View.IsSeachPlayer(Enemy.transform.position, View.Direction))
        {
            EnemyStateMachine.SwitchState<EnemyFollowState>();
        }

        _timer += Time.deltaTime;
        
        if (_timer >= Enemy.Wait)
        {
            EnemyStateMachine.SwitchState<EnemyMovingState>();
        }
    }

    public override void FixedUpdate() { }

    public override void Exit() { }
}