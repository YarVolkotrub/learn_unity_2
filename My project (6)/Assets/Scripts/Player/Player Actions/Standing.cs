using UnityEngine;

public class standing : Mover
{
    public void Stand()
    {
        Rigidbody.velocity = Vector2.zero;
    }
}