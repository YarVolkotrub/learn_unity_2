using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    private float _groundRadius = 0.05f;
    private string _layerGround = "Ground";

    private float _runSpeed = 4f;
    private float _jumpForce = 7f;
    private float _jumpMoveSpeed = 3f;
    private float _fallMoveSpeed = 2f;
    private bool _isDoubleJump = true;
    private float _delayDoubleJump = 0.5f;

    private Rigidbody2D _rigidbody;

    public float DelayDoubleJump => _delayDoubleJump;
    public Rigidbody2D RigidbodyPlayer => _rigidbody;
    public bool IsDoubleJump => _isDoubleJump;
    public float RunSpeed => _runSpeed;
    public float JumpForce => _jumpForce;
    public float JumpMoveSpeed => _jumpMoveSpeed;
    public float FallMoveSpeed => _fallMoveSpeed;
    public bool IsFalling => _rigidbody.velocity.y < 0;
    public bool IsJumping => _rigidbody.velocity.y > 0;
    public bool IsRestUpDown => _rigidbody.velocity.y == 0;
    public bool OnGround => Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ActiveDoubleJump()
    {
        _isDoubleJump = true;
    }

    public void DisableDoubleJump()
    {
        _isDoubleJump = false;
    }
}