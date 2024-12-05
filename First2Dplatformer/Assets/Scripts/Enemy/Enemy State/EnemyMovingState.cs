using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    private int _spot = 1;
    [SerializeField] private float _distance = 10f;

    public EnemyMovingState(EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        EnemyAnimation.Move();
        _spot = (_spot == 1) ? 0 : 1;
        Direction = Mover.SetDirection(Enemy.PointsSpots[_spot].position.x);
        Mover.Flip(Direction);
    }

    public override void Update()
    {
        SeachPlayer();
        
        if (Mover.IsEndPoint(Enemy.PointsSpots[_spot].position, Enemy.MinDistanceForTarget) || Enemy.OnGround == false)
        {
            EnemyStateMachine.SwitchState<EnemyIdleState>();
        }
    }

    public override void FixedUpdate() 
    {
        Mover.Move(Enemy.PointsSpots[_spot].position, Enemy.Speed);
    }

    

    public void SeachPlayer()
    {
        //RaycastHit2D raycastHit2D = Physics2D.Raycast(Enemy.transform.position, Direction, _distance, LayerMask.GetMask("Player"));
        //Debug.DrawRay(Enemy.transform.position, Direction * _distance, Color.red);
        //if (raycastHit2D.collider != null)
        //{
        //    if (raycastHit2D.collider.gameObject.tag == "Player")
        //    {
        //        EnemyStateMachine.SwitchState<EnemyFollowState>();
        //    }
        //}
    }
    public override void Exit() { }
}