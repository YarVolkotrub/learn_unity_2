using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAnimation))]
public class Enemy : MonoBehaviour, IEnemyCombat, ICheckOnGround, IEnemyHealth
{
    [SerializeField] protected Transform[] _pointsSpots;
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected Rigidbody2D Rigidbody;
    [SerializeField, Range(1, 100)] protected int MaxHealth;
    [SerializeField, Range(1, 10)] protected float SpeedMove;
    [SerializeField, Range(1, 10)] protected float WaitSecond;
    [SerializeField] private Player _target;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField, Range(0, 2)] private float _delayAttack = 1f;
    [SerializeField, Range(0, 2)] private float _distanceAttack = 1f;

    protected IEnemyAnimation EnemyAnimation => _enemyAnimation;
    protected IEnemyMover Mover;
    protected IEnemyView View;
    protected IEnemyHealth Health;
    protected EnemyStateMachine EnemyStateMachine;

    private float _minDistanceForTarget = 0.2f;
    private string _layerGround = "Ground";
    private float _groundRadius = 0.05f;

    public float DelayAttack => _delayAttack;
    public float DistanceAttack => _distanceAttack;
    public ITarget Target => _target;
    public float MinDistanceForTarget => _minDistanceForTarget;
    public float Speed => SpeedMove;
    public float Wait => WaitSecond;
    public Transform[] PointsSpots => _pointsSpots;
    public Rigidbody2D RigidbodyEnemy => Rigidbody;
    public bool OnGround => Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }
}