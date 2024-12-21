using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysics : MonoBehaviour, ICheckOnGround, IPlayerPhysics
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField, Range(1, 5)] private float _runSpeed = 4f;
    [SerializeField, Range(3, 8)] private float _jumpForce = 7f;
    [SerializeField, Range(1, 5)] private float _jumpMoveSpeed = 3f;
    [SerializeField, Range(1, 5)] private float _fallMoveSpeed = 2f;
    [SerializeField, Range(0, 2)] private float _delayDoubleJump = 0.5f;
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _groundRadius = 0.05f;
    private string _layerGround = "Ground";
    private bool _isDoubleJump = true;

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
    public bool IsMove => _rigidbody.velocity.x != 0;
    public bool OnGround => Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, LayerMask.GetMask(_layerGround));

    public void ActiveDoubleJump()
    {
        _isDoubleJump = true;
    }

    public void DisableDoubleJump()
    {
        _isDoubleJump = false;
    }
}