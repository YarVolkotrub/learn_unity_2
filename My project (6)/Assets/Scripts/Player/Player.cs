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

    private void ChangeState()
    {
        _moveDirection = _controller.MoveDirection;
        _playerPhysics.Flip(_moveDirection);

        if (_playerPhysics.OnGround() == true)
        {
            if (_controller.Jump)
            {
                _characterState.Change(_jumpState);
            }

            if (_moveDirection == Vector2.zero || _controller.Stay)
            {
                _characterState.Change(_idleState);
            }

            if (_moveDirection != Vector2.zero)
            {
                transform.Translate(_moveDirection * _playerPhysics.RunSpeed * Time.deltaTime, Space.World);

                //_playerPhysics.RigidbodyPlayer.AddForce(_moveDirection * _playerPhysics.RunSpeed, ForceMode2D.Impulse);
                _characterState.Change(_runState);
            }
        }
        else if (_playerPhysics.OnGround() == false)
        {
            if (_playerPhysics.IsFalling)
            {
                _characterState.Change(_fallState);
            }

            if (_playerPhysics.IsJumping)
            {
                _characterState.Change(_jumpState);
            }
        }
    }
}