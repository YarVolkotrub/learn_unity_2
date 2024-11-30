using UnityEngine;

public class Officer : Enemy
{
    private void Awake()
    {
        EnemyAnimation = GetComponent<EnemyAnimation>();
        Rigidbody = GetComponent<Rigidbody2D>();

        SpeedMove = 1f;
        WaitSecond = 2f;
    }

    private void Start()
    {
        Mover = new Mover(Rigidbody, transform);
        EnemyStateMachine = new EnemyStateMachine(EnemyAnimation, Mover, this);
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