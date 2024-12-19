using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAnimation))]
public class Enemy : MonoBehaviour, IEnemyCombat, ICheckOnGround, IEnemyHealth
{
    [SerializeField] protected Transform[] PointsSpots;
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected Rigidbody2D Rigidbody;
    [SerializeField] protected int MaxHealthPoint = 100;
    [SerializeField] private float SpeedMove = 1;
    [SerializeField] private float WaitSecond = 1;
    [SerializeField] private Player _target;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private float _delayAttack = 1f;
    [SerializeField] private float _distanceAttack = 1f;


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
    public Transform[] Spots => PointsSpots;
    public Rigidbody2D RigidbodyEnemy => Rigidbody;
    public bool OnGround => Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }
}