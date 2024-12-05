using UnityEngine;

public class Cutthroat : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        EnemyStateMachine = new EnemyStateMachine(EnemyAnimation, Mover, this);

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
}