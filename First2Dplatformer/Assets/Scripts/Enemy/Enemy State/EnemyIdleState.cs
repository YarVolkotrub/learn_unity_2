using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private float _timer;

    public EnemyIdleState(IEnemyView view, IEnemyAnimation enemyAnimation, IEnemyMover mover, IStateSwitcher stateMachine, Enemy enemy) 
        : base(view, enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        _timer = 0;
        EnemyAnimation.Idle();
        Mover.Stand();
    }

    public override void Update()
    {
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
}