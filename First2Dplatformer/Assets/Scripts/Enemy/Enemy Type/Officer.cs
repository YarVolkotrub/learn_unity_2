public class Officer : Enemy
{
    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new VisionEnemy();
        Health = new Health(MaxHealthPoint);
        Animator.Init();
        StateMachine = new StateMachine(View, Animation, Mover, this);
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