using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : IState
{
    private PlayerAnimation _animator;
    private Rigidbody2D _rigidbody;
    private float _fallForce;
    private float _maxFallForce;

    public FallState(PlayerAnimation animator, Rigidbody2D playerPhysics, float fallForce)
    {
        _animator = animator;
        _rigidbody = playerPhysics;
        _fallForce = fallForce;
    }

    public void Enter()
    {
        _animator.Fall();
    }

    public void Update() 
    {
        
    }

    public void Exit() {}
}
