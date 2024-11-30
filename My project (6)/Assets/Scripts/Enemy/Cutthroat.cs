using UnityEngine;

public class Cutthroat : Enemy
{
    private void Awake()
    {
        EnemyAnimation = GetComponent<EnemyAnimation>();
        Rigidbody = GetComponent<Rigidbody2D>();
        
        SpeedMove = 2f;
        WaitSecond = 5f;
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