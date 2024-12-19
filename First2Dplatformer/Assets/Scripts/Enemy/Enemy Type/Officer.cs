public class Officer : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new EnemyView();
        Health = new EnemyHealth();
        EnemyStateMachine = new EnemyStateMachine(View, EnemyAnimation, Mover, this);

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