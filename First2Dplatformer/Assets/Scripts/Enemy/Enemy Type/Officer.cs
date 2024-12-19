public class Officer : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new EnemyView();
        Health = new EnemyHealth(MaxHealthPoint);
        EnemyStateMachine = new EnemyStateMachine(View, EnemyAnimation, Mover, this);
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