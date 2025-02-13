using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour, IEnemyCombat, ICheckOnGround, IHealth
{
    [SerializeField] protected Transform[] PointsSpots;
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected Rigidbody2D Rigidbody;
    [SerializeField] protected int MaxHealthPoint = 100;
    [SerializeField] private float SpeedMove = 1;
    [SerializeField] private float WaitSecond = 1;
    [SerializeField] private Player _target;
    [SerializeField] protected EnemyAnimator Animator;
    [SerializeField] private float _delayAttack = 1f;
    [SerializeField] private float _distanceAttack = 1f;

    protected IEnemyMover Mover;
    protected IVisionEnemy View;
    protected IHealth Health;
    protected StateMachine StateMachine;

    private float _minDistanceForTarget = 0.2f;
    private string _layerGround = "Ground";
    private float _groundRadius = 0.05f;

    protected IEnemyAnimator Animation => Animator;
    public float DelayAttack => _delayAttack;
    public float DistanceAttack => _distanceAttack;
    public ITarget Target => _target;
    public float MinDistanceForTarget => _minDistanceForTarget;
    public float Speed => SpeedMove;
    public float Wait => WaitSecond;
    public Transform[] Spots => PointsSpots.ToArray();
    public Rigidbody2D RigidbodyEnemy => Rigidbody;
    public bool OnGround => Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }
}