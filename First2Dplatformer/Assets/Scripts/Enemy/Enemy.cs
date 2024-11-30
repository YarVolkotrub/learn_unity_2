using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAnimation))]
public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D Rigidbody;
    protected EnemyAnimation EnemyAnimation;
    protected Mover Mover;
    protected EnemyStateMachine EnemyStateMachine;

    protected float SpeedMove;
    protected float WaitSecond;

    [SerializeField] protected Transform[] _pointsSpots;
    private float _minDistanceForTarget = 0.2f;

    [SerializeField] protected Transform GroundCheck;
    private string _layerGround = "Ground";
    private float _groundRadius = 0.05f;

    public float MinDistanceForTarget => _minDistanceForTarget;
    public float Speed => SpeedMove;
    public float Wait => WaitSecond;
    public Transform[] PointsSpots => _pointsSpots;
    public Rigidbody2D RigidbodyEnemy => Rigidbody;
    public bool OnGround => Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));
}