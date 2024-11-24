using UnityEngine;

[RequireComponent(typeof(StateMachinePlayer))]
[RequireComponent(typeof(InputSystem))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerPhysics))]
[RequireComponent(typeof(PlayerInventory))]
public class Player : MonoBehaviour
{
    private StateMachinePlayer _characterState;
    private InputSystem _controller;
    private PlayerAnimation _playerAnimation;
    private PlayerPhysics _playerPhysics;
    private PlayerInventory _playerInventory;

    private IdleState _idleState;
    private RunState _runState;
    private JumpState _jumpState;
    private FallState _fallState;
    
    private Vector2 _moveDirection;

    private void Awake()
    {
        _controller = GetComponent<InputSystem>();
        _characterState = GetComponent<StateMachinePlayer>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerPhysics = GetComponent<PlayerPhysics>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void Start()
    {
        InitState();
        _characterState.Change(_idleState);
    }

    private void Update()
    {
        ChangeState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            _playerInventory.AddItem(item);
            item.Destroy();
        }
    }

    private void InitState()
    {
        _idleState = new IdleState(_playerAnimation);
        _runState = new RunState(_playerAnimation, _playerPhysics.RigidbodyPlayer, Vector2.zero, _playerPhysics.RunSpeed);
        _jumpState = new JumpState(_playerAnimation, _playerPhysics.RigidbodyPlayer, _playerPhysics.JumpForce);
        _fallState = new FallState(_playerAnimation, _playerPhysics.RigidbodyPlayer, _playerPhysics.FallForce);
    }

    private Vector2 TMPMover()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"));
    }

    private float tmpSpeed = 5f;
    private float tmpJumpForce = 7f;

    private void ChangeState()
    {
        _moveDirection = _controller.MoveDirection;
        //_moveDirection = TMPMover()
        _playerPhysics.Flip(_moveDirection);

        if (_playerPhysics.OnGround() == true) // Состояния на земле
        {
            // Движение up по Y
            //if (_controller.Jump)
            if (_controller.JumpDirection == Vector2.up)
            //if (_moveDirection == Vector2.up)
            {
                _characterState.Change(_jumpState);
                _playerPhysics.RigidbodyPlayer.velocity = new Vector2(_playerPhysics.RigidbodyPlayer.velocity.x, tmpJumpForce);
            }

            // покой по X,Y
            if ((_moveDirection == Vector2.zero || _controller.Stay) && _playerPhysics.IsRest)
            {
                _characterState.Change(_idleState);
                _playerPhysics.RigidbodyPlayer.velocity = Vector2.zero;
            }

            // Движение по X
            if ((_moveDirection == Vector2.left || _moveDirection == Vector2.right) && _playerPhysics.IsRest)
            //if (_moveDirection != Vector2.zero)
            {
                _playerPhysics.RigidbodyPlayer.velocity = new Vector2(10, 0);
                //transform.Translate(_moveDirection * tmpSpeed * Time.deltaTime, Space.World);
                _playerPhysics.RigidbodyPlayer.velocity = new Vector2(_moveDirection.x * tmpSpeed, _playerPhysics.RigidbodyPlayer.velocity.y);
                //_playerPhysics.RigidbodyPlayer.AddForce(_moveDirection * tmpSpeed, ForceMode2D.Impulse);
                //_playerPhysics.RigidbodyPlayer.AddForce(_moveDirection * tmpSpeed);
                //transform.Translate(_moveDirection * tmpSpeed * Time.deltaTime);
                _characterState.Change(_runState);
            }
        }
        else if (_playerPhysics.OnGround() == false) // Состояние вне земли
        {
            if (_playerPhysics.IsFalling) // velocity.y < 0
            {
                _characterState.Change(_fallState);
            }

            if (_playerPhysics.IsJumping) // velocity.y > 0
            {
                _characterState.Change(_jumpState);
            }
        }
    }
}