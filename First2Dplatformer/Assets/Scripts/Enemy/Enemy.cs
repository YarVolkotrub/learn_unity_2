using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour, IEnemyCombat, ICheckOnGround, IHealth
{
    [SerializeField] private Transform[] PointsSpots;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private Rigidbody2D Rigidbody;
    [SerializeField] private int MaxHealthPoint = 100;
    [SerializeField] private float SpeedMove = 1;
    [SerializeField] private float WaitSecond = 1;
    [SerializeField] private Player _target;
    [SerializeField] private EnemyAnimator Animator;
    [SerializeField] private float _delayAttack = 1f;
    [SerializeField] private float _distanceAttack = 1f;

    private IEnemyMover Mover;
    private IVisionEnemy View;
    private IHealth Health;
    private StateMachine StateMachine;

    private float _minDistanceForTarget = 0.2f;
    private string _layerGround = "Ground";
    private float _groundRadius = 0.05f;

    public void Init()
    {
        Mover = new EnemyMover(Rigidbody, transform);
        View = new VisionEnemy();
        Health = new Health(MaxHealthPoint);
        Animator.Init();
        StateMachine = new StateMachine(View, Animation, Mover, this);
    }

    private IEnemyAnimator Animation => Animator;
    public float DelayAttack => _delayAttack;
    public float DistanceAttack => _distanceAttack;
    public ITarget Target => _target;
    public float MinDistanceForTarget => _minDistanceForTarget;
    public float Speed => SpeedMove;
    public float Wait => WaitSecond;
    public Transform[] Spots => PointsSpots.ToArray();
    public Rigidbody2D RigidbodyEnemy => Rigidbody;
    public bool OnGround => Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));

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

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }
}