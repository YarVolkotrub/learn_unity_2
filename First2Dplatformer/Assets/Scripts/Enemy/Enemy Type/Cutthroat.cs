using UnityEngine;

public class Cutthroat : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new EnemyView();
        Health = new EnemyHealth(MaxHealthPoint);
        Animator.Init();
        StateMachine = new EnemyStateMachine(View, Animation, Mover, this);
    }

    private void Start()
    {
        StateMachine.SwitchState<EnemyIdleState>();
    }
    
    private void Update()
    {
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }
}