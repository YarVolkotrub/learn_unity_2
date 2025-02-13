using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float _timer;
    private float _lenghtAnimation;

    public EnemyAttackState(IVisionEnemy view, IEnemyAnimator enemyAnimation, IEnemyMover mover, IStateSwitcher stateMachine, Enemy enemy) 
        : base(view, enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        Mover.Stand();
        _timer = Enemy.DelayAttack;
        EnemyAnimation.Attack();
    }

    public override void Update()
    {
        if (_lenghtAnimation == 0)
        {
            _lenghtAnimation = EnemyAnimation.Lenght + Enemy.DelayAttack;
        }

        if (_timer >= _lenghtAnimation)
        {
            if (View.IsSeachPlayer(Enemy.transform.position, View.Direction) == false)
            {
                EnemyStateMachine.SwitchState<EnemyIdleState>();
            }
            else if (Mover.IsEndPoint(Enemy.Target.Position, Enemy.DistanceAttack) == false)
            {
                EnemyStateMachine.SwitchState<EnemyFollowState>();
            }
            else
            {
                _timer = 0;
                EnemyAnimation.Attack();
            }
        }

        _timer += Time.deltaTime;
    }
}