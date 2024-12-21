public class Officer : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new EnemyView();
        Health = new EnemyHealth(MaxHealthPoint);
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