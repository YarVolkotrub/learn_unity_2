using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    private int _spot = 1;
    private Vector2 _direction;

    public EnemyMovingState(IVisionEnemy view, IEnemyAnimator enemyAnimation, IEnemyMover mover, IStateSwitcher stateMachine, Enemy enemy) 
        : base(view, enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        EnemyAnimation.Move();
        _spot = (_spot == 1) ? 0 : 1;
        _direction = Mover.SetDirection(Enemy.Spots[_spot].position.x);
        View.SetDirection(_direction);
        Mover.Flip(_direction);
    }

    public override void Update()
    {
        if (Enemy.OnGround && View.IsSeachPlayer(Enemy.transform.position, View.Direction))
        {
            EnemyStateMachine.SwitchState<EnemyFollowState>();
        }
        else if (Mover.IsEndPoint(Enemy.Spots[_spot].position, Enemy.MinDistanceForTarget) || Enemy.OnGround == false)
        {
            EnemyStateMachine.SwitchState<EnemyIdleState>();
        }
    }

    public override void FixedUpdate() 
    {
        Mover.Move(Enemy.Spots[_spot].position, Enemy.Speed);
    }
}