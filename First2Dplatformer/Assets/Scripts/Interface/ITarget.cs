using UnityEngine;

public interface ITarget
{
    public Vector2 Position { get; }

    public void TakeDamage(int damage);
}