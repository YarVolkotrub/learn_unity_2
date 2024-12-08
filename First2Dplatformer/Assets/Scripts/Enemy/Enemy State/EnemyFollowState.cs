public class EnemyFollowState : EnemyBaseState
{
    public EnemyFollowState(EnemyView view, EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(view, enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        EnemyAnimation.Move();
    }

    public override void Update()
    {
        
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

    public override void Exit() { }
}