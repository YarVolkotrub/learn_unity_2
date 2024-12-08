using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAnimation))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform[] _pointsSpots;
    [SerializeField] protected Transform GroundCheck;
    [SerializeField, Range(1, 100)] protected int MaxHealth;
    [SerializeField, Range(1, 10)] protected float SpeedMove;
    [SerializeField, Range(1, 10)] protected float WaitSecond;
    [SerializeField] private Player _playert;
    [SerializeField] protected Rigidbody2D Rigidbody;
    [SerializeField] protected EnemyAnimation EnemyAnimation;

    protected int Health;
    protected Vector2 StartPosition;
    protected EnemyMover Mover;
    protected EnemyStateMachine EnemyStateMachine;
    protected EnemyView View;

    private float _minDistanceForTarget = 0.2f;
    private string _layerGround = "Ground";
    private float _groundRadius = 0.05f;

    public ITarget Target => _playert;
    public Vector2 FirstPointPosition => StartPosition; 
    public float MinDistanceForTarget => _minDistanceForTarget;
    public float Speed => SpeedMove;
    public float Wait => WaitSecond;
    public Transform[] PointsSpots => _pointsSpots;
    public Rigidbody2D RigidbodyEnemy => Rigidbody;
    public bool OnGround => Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));
}