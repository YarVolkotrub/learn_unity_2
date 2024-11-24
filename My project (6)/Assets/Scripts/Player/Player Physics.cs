using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
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

    public void Flip(Vector2 position)
    {
        float direction = position.x;

        if (_currentPosition == direction)
        {
            return;
        }

        Vector2 rotate = transform.eulerAngles;

        if (_currentPosition > direction)
        {
            rotate.y = _rightDirection;
        }
        else if (_currentPosition < direction)
        {
            rotate.y = _leftDirection;
        }

        transform.rotation = Quaternion.Euler(rotate);
    }
}