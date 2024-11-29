using UnityEngine;

public class Officer : Enemy
{
    private void Awake()
    {
        EnemyAnimation = GetComponent<EnemyAnimation>();
        Rigidbody = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
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
        Debug.DrawRay(transform.position, Vector2.left * 2, Color.red);
        EnemyStateMachine.Update();
    }

    private void FixedUpdate()
    {
        EnemyStateMachine.FixedUpdate();
    }
}