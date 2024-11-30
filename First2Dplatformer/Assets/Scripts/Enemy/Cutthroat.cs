using UnityEngine;

public class Cutthroat : Enemy
{
    public void Init()
    {
        EnemyAnimation = GetComponent<EnemyAnimation>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Mover = new Mover(Rigidbody, transform);
        EnemyStateMachine = new EnemyStateMachine(EnemyAnimation, Mover, this);
        SpeedMove = 2f;
        WaitSecond = 5f;
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