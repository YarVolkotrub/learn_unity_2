//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MovementSM : StateMachine
//{
//    public Idle idleState { get; private set; }
//    public Moving movingState { get; private set; }
//    public float speed = 4f;
//    public Rigidbody2D rigidbody => GetComponent<Rigidbody2D>();

//    private void Awake()
//    {
//        idleState = new Idle(this);
//        movingState = new Moving(this);
//    }

//    protected override State GetInitialState()
//    {
//        return idleState;
//    }
//}