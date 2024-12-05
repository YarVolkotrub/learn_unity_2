using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowState : EnemyBaseState
{
    [SerializeField] private float _distance = 10f;

    public EnemyFollowState(EnemyAnimation enemyAnimation, EnemyMover mover, EnemyStateMachine stateMachine, Enemy enemy) 
        : base(enemyAnimation, mover, stateMachine, enemy) { }

    public override void Enter()
    {

    }

    public override void Update()
    {
        

    }

    public override void FixedUpdate() 
    {
        SeachPlayer();
    }

    public override void Exit() { }

    public void SeachPlayer()
    {
        //RaycastHit2D raycastHit2D = Physics2D.Raycast(Enemy.transform.position, Direction, _distance, LayerMask.GetMask("Player"));

        //if (raycastHit2D.collider != null)
        //{
        //    if (raycastHit2D.collider.gameObject.tag == "Player")
        //    {
        //        Vector2 target = Enemy.Target.Position;
        //        Mover.Move(target, Enemy.Speed);
        //    }
        //}
        //else
        //{
        //    EnemyStateMachine.SwitchState<EnemyIdleState>();
        //}
    }
}