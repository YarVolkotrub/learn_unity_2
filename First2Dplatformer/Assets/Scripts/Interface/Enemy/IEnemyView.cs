using UnityEngine;

public interface IEnemyView
{
    public float Distance { get; }
    public Vector2 Direction { get; }
    public bool IsSeachPlayer(Vector2 position, Vector2 direction);
    public void SetDirection(Vector2 direction);
}