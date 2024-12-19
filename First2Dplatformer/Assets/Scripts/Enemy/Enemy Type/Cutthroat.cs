public class Cutthroat : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new EnemyView();
        Health = new EnemyHealth();
        EnemyStateMachine = new EnemyStateMachine(View, EnemyAnimation, Mover, this);

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