using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    private int _spot = 1;
    private Vector2 _moveDirection;

    public EnemyMovingState(EnemyAnimation enemyAnimation, Mover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        EnemyAnimation.Move();
        _spot = (_spot == 1) ? 0 : 1;
        Flip();
    }

    public override void Update()
    {
        if ((Vector2.Distance(Enemy.transform.position, Enemy.PointsSpots[_spot].position) < Enemy.MinDistanceForTarget) || Enemy.OnGround == false)
        {
            EnemyStateMachine.SwitchState<EnemyIdleState>();
        }
    }

    public override void FixedUpdate() 
    {
        Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Enemy.PointsSpots[_spot].position, Enemy.Speed * Time.fixedDeltaTime);
    }

    public override void Exit() { }

    private void Flip()
    {
        if (Enemy.transform.position.x < Enemy.PointsSpots[_spot].position.x)
        {
            _moveDirection = Vector2.left;
        }
        else
        {
            _moveDirection = Vector2.right;

        }

        Mover.Flip(_moveDirection);
    }
}