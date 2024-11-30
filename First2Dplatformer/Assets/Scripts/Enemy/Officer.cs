using UnityEngine;

public class Officer : Enemy
{
    public void Init()
    {
        EnemyAnimation = GetComponent<EnemyAnimation>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Mover = new Mover(Rigidbody, transform);
        EnemyStateMachine = new EnemyStateMachine(EnemyAnimation, Mover, this);

        SpeedMove = 1f;
        WaitSecond = 2f;
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