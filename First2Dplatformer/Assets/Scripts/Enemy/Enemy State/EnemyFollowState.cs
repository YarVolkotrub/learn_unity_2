public class EnemyFollowState : EnemyBaseState
{
    public EnemyFollowState(IEnemyView view, IEnemyAnimation enemyAnimation, IEnemyMover mover, IStateSwitcher stateMachine, Enemy enemy) 
        : base(view, enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        EnemyAnimation.Move();
    }

    public override void Update()
    {
        if (Mover.IsEndPoint(Enemy.Target.Position, Enemy.DistanceAttack))
        {
            EnemyStateMachine.SwitchState<EnemyAttackState>();
        }
    }

    public override void FixedUpdate() 
    {
        if ((Enemy.OnGround == false) || (View.IsSeachPlayer(Enemy.transform.position, View.Direction) == false))
        {
            EnemyStateMachine.SwitchState<EnemyIdleState>();
        }
        else
        {
            Mover.Move(Enemy.Target.Position, Enemy.Speed);
        }
    }
}