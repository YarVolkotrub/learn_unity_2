using UnityEngine;

public class RunState : IState
{
    private PlayerAnimation _animator;
    private Rigidbody2D _rigidbody;
    private float _speed;

    public Vector2 Direction { get; set; }

    public RunState(PlayerAnimation animator, Rigidbody2D _playerPhysics, Vector2 direction, float speed)
    {
        _animator = animator;
        _rigidbody = _playerPhysics;
        Direction = direction;
        _speed = speed;
        
    }

    public void Enter()
    {
        
        _animator.Move();
    }

    public void Update() 
    {
        //_rigidbody.AddForce(Direction * _speed, ForceMode2D.Impulse);
    }

    public void Exit() {}
}