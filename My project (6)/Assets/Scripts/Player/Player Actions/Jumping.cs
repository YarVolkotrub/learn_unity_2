using UnityEngine;

public class Jumping : Mover
{
    private void Jump()
    {
        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpForce);
    }
}