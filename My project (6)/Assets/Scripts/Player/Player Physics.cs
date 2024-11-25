using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _ceiling;
    private float _groundRadius = 0.3f;
    private string _layerGround = "Ground";

    private float _runSpeed = 3f;
    private float _jumpForce = 7f;
    private float _jumpMoveSpeed = 3f;
    private float _fallMoveSpeed = 2f;
    
    private float _currentPosition = 0;
    private float _rightDirection = 180;
    private float _leftDirection = 0;

    private Rigidbody2D _rigidbody;

    public float RunSpeed => _runSpeed;
    public float JumpForce => _jumpForce;
    public float JumpMoveSpeed => _jumpMoveSpeed;
    public float FallMoveSpeed => _fallMoveSpeed;
    public bool IsFalling => _rigidbody.velocity.y < 0;
    public bool IsJumping => _rigidbody.velocity.y > 0;
    public bool IsRestUpDown => _rigidbody.velocity.y == 0;
    public Rigidbody2D RigidbodyPlayer => _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public bool OnGround()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));
    }

    public bool OnCeiling()
    {
        return Physics2D.OverlapCircle(_ceiling.position, _groundRadius, LayerMask.GetMask(_layerGround));
    }
}