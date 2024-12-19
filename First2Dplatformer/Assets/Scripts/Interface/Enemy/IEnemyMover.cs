using UnityEngine;

public interface IEnemyMover
{
    public void Move(Vector2 targetPosition, float speed);
    public void Stand();
    public bool IsEndPoint(Vector2 targetPosition, float minDistanceForTarget);
    public Vector2 SetDirection(float targetPosition);
    public void Flip(Vector2 direction);
}