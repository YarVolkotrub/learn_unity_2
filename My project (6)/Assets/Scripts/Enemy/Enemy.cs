using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyAnimation))]
public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D Rigidbody;
    protected EnemyAnimation EnemyAnimation;
    protected Mover Mover;
    protected EnemyStateMachine EnemyStateMachine;

    protected Vector3 StartPosition;
    protected float SpeedMove;
    protected float WaitSecond;
    protected RaycastHit2D View;
    protected Vector3 Direction;

    [SerializeField] protected GameObject PatrolPointLeft;
    [SerializeField] protected GameObject PatrolPointRight;
    [SerializeField] protected bool IsPatrolman;
    [SerializeField] protected Transform GroundCheck;
    private string _layerGround = "Ground";
    private float _groundRadius = 0.05f;

    public float Speed => SpeedMove;
    public float Wait => WaitSecond;
    public bool IsPatrol => IsPatrolman;
    public Rigidbody2D RigidbodyEnemy => Rigidbody;
    public bool OnGround => Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));
}