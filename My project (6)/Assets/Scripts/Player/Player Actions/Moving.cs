using UnityEngine;

public class Moving : Mover
{ 
    public void Run()
    {
        Rigidbody.velocity = new Vector2(Direction.x * MoveSpeed, Rigidbody.velocity.y);
    }
}