using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private float _timer;
    [SerializeField] private float _distance = 10f;

    public EnemyIdleState(EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {
        _timer = 0;
        EnemyAnimation.Idle();
        Mover.Stand();
    }

    public override void Update()
    {
        SeachPlayer();
        Debug.DrawRay(Enemy.transform.position, Direction * _distance, Color.red);
        _timer += Time.deltaTime;
        
        if (_timer >= Enemy.Wait)
        {
            EnemyStateMachine.SwitchState<EnemyMovingState>();
        }
    }

    

    public void SeachPlayer()
    {

        //RaycastHit2D raycastHit2D = Physics2D.Raycast(Enemy.transform.position, Direction, _distance, LayerMask.GetMask("Player"));

        //if (raycastHit2D.collider != null)
        //{
        //    if (raycastHit2D.collider.gameObject.tag == "Player")
        //    {
        //        EnemyStateMachine.SwitchState<EnemyFollowState>();
        //    }
        //}
    }

    public override void FixedUpdate() { }

    public override void Exit() { }
}