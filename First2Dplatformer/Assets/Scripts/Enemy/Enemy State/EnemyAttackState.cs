public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyView view, EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(view, enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        EnemyAnimation.Attack();
    }

    public override void Update()
    {
        
    }

    public override void FixedUpdate() 
    {

    }

    public override void Exit() { }
}