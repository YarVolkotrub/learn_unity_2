using UnityEngine;

public class Cutthroat : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new EnemyView();
        EnemyStateMachine = new EnemyStateMachine(View, EnemyAnimation, Mover, this);

        StartPosition = transform.position;
        SpeedMove = 2f;
        WaitSecond = 5f;
        Health = MaxHealth;
    }

    private void Start()
    {
        EnemyStateMachine.SwitchState<EnemyIdleState>();
    }
    
    private void Update()
    {
        EnemyStateMachine.Update();
    }

    private void FixedUpdate()
    {
        EnemyStateMachine.FixedUpdate();
    }

    public void OnAnimationEvent()
    {
        Debug.Log("Animation Event Triggered!");
    }

    private void Attack()
    {

    }
}