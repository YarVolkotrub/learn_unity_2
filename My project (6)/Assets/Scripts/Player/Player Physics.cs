using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysics : MonoBehaviour
{
    private float _runSpeed = 5f;
    private float _jumpForce = 7f;
    private float _fallForce = 30f;
    private float _rayDistance = 0.8f;
    private string _layerGround = "Ground";
    private Rigidbody2D _rigidbody;

    private float _currentPosition = 0;
    private float _rightDirection = 180;
    private float _leftDirection = 0;

    public float RunSpeed => _runSpeed;
    public float JumpForce => _jumpForce;
    public float FallForce => _fallForce;
    public bool IsFalling => _rigidbody.velocity.y < 0;
    public bool IsJumping => _rigidbody.velocity.y > 0;
    public Rigidbody2D RigidbodyPlayer => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public bool OnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position, Vector2.down, _rayDistance, LayerMask.GetMask(_layerGround));

        if (hit.collider == null)
        {
            return false;
        }

        return true;
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