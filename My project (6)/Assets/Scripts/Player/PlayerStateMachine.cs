using UnityEngine;

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

    private Vector2 _moveDirection;

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
        _idleState = new IdleState(_playerAnimation);
        _runState = new RunState(_playerAnimation);
        _jumpState = new JumpState(_playerAnimation);
        _fallState = new FallState(_playerAnimation);
    }

    private void ChangeState()
    {
        _moveDirection = _controller.MoveDirection;
        //_playerPhysics.Flip(_moveDirection);
        _mover.Flip(_moveDirection);

        if (_playerPhysics.OnGround() == true) // Состояния на земле
        {
            // Движение по X
            if ((_moveDirection == Vector2.left || _moveDirection == Vector2.right) && _playerPhysics.IsRestUpDown)
            {
                _mover.Move(_moveDirection.x, _playerPhysics.RunSpeed, _playerPhysics.RigidbodyPlayer.velocity.y);
                _characterState.Change(_runState);
            }

            // Движение up по Y
            if (_controller.JumpDirection == Vector2.up)
            {
                _mover.Jump(_playerPhysics.RigidbodyPlayer.velocity.x, _playerPhysics.JumpForce);
                _characterState.Change(_jumpState);
            }

            // покой по X,Y
            if ((_moveDirection == Vector2.zero || _controller.Stay) && _playerPhysics.IsRestUpDown)
            {
                _mover.Stand();
                _characterState.Change(_idleState);
            }


        }
        else if (_playerPhysics.OnGround() == false) // Состояние вне земли
        {
            if (_playerPhysics.IsFalling) // velocity.y < 0
            {
                _mover.Move(_moveDirection.x, _playerPhysics.FallMoveSpeed, _playerPhysics.RigidbodyPlayer.velocity.y);
                _characterState.Change(_fallState);
            }

            if (_playerPhysics.IsJumping) // velocity.y > 0
            {
                _mover.Move(_moveDirection.x, _playerPhysics.JumpMoveSpeed, _playerPhysics.RigidbodyPlayer.velocity.y);
                _characterState.Change(_jumpState);
            }
        }
    }
}