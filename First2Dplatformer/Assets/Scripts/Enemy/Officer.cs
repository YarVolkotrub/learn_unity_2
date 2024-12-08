using UnityEngine;

public class Officer : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new EnemyView();
        EnemyStateMachine = new EnemyStateMachine(View, EnemyAnimation, Mover, this);

        StartPosition = transform.position;
        SpeedMove = 1f;
        WaitSecond = 2f;
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