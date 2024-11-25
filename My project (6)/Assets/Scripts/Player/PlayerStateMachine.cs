using UnityEngine;

[RequireComponent(typeof(InputSystem))]
[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerPhysics))]
public class PlayerStateMachine : MonoBehaviour
{
    private StateMachine _characterState;
    private InputSystem _controller;
    private PlayerAnimation _playerAnimation;
    private PlayerPhysics _playerPhysics;

    private IdleState _idleState;
    private RunState _runState;
    private JumpState _jumpState;
    private FallState _fallState;

    private Mover _mover;

    private float _moveDirection;

    private void Awake()
    {
        _controller = GetComponent<InputSystem>();
        _characterState = GetComponent<StateMachine>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerPhysics = GetComponent<PlayerPhysics>();
    }

    private void Start()
    {
        _mover = new Mover(_playerPhysics.RigidbodyPlayer, transform);
        InitState();
        _characterState.Change(_idleState);
    }

    private void Update()
    {
        ChangeState();
    }

    private void InitState()
    {
        _idleState = new IdleState(_playerAnimation, _mover);
        _runState = new RunState(_playerAnimation, _mover);
        _jumpState = new JumpState(_playerAnimation, _mover);
        _fallState = new FallState(_playerAnimation, _mover);
    }

    private void ChangeState()
    {
        _moveDirection = _controller.MoveDirection;
        _mover.Flip(_moveDirection);
        Debug.Log(_playerPhysics.RigidbodyPlayer.velocity.y);

        if (_playerPhysics.OnGround() == true) // Состояния на земле
        {
            // Движение по X
            if ((_moveDirection >= Vector2.left.x || _moveDirection <= Vector2.right.x) && _playerPhysics.IsRestUpDown && _moveDirection != Vector2.zero.x)
            {
                _mover.Move(_moveDirection, _playerPhysics.RunSpeed, _playerPhysics.RigidbodyPlayer.velocity.y);
                _characterState.Change(_runState);
            }

            // Движение up по Y
            if (_controller.JumpDirection == Vector2.up.y)
            {
                _mover.Jump(_playerPhysics.RigidbodyPlayer.velocity.x, _playerPhysics.JumpForce);
                _characterState.Change(_jumpState);
            }

            // покой по X,Y
            if (((_moveDirection == Vector2.zero.x && _moveDirection == Vector2.zero.y) || _controller.Stay) && _playerPhysics.IsRestUpDown)
            {
                _mover.Stand();
                _characterState.Change(_idleState);
            }
        }
        else if (_playerPhysics.OnGround() == false) // Состояние вне земли
        {
            if (_playerPhysics.IsFalling || _playerPhysics.OnCeiling()) // velocity.y < 0
            {
                _mover.Move(_moveDirection, _playerPhysics.FallMoveSpeed, _playerPhysics.RigidbodyPlayer.velocity.y);
                _characterState.Change(_fallState);
            }

            if (_playerPhysics.IsJumping) // velocity.y > 0
            {
                _mover.Move(_moveDirection, _playerPhysics.JumpMoveSpeed, _playerPhysics.RigidbodyPlayer.velocity.y);
                _characterState.Change(_jumpState);
            }
        }
    }
}