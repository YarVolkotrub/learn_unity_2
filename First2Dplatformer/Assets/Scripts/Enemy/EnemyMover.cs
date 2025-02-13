using UnityEngine;

public class EnemyMover: Mover, IEnemyMover
{
    public EnemyMover(Rigidbody2D rigidbody, Transform transform) : base(rigidbody, transform) { }

    public void Move(Vector2 targetPosition, float speed)
    {
        _transform.position = Vector2.MoveTowards(_transform.position, targetPosition, speed * Time.fixedDeltaTime);
    }

    public bool IsEndPoint(Vector2 targetPosition, float minDistanceForTarget)
    {
        Vector2 currentPosition = _transform.position;

        return (currentPosition - targetPosition).sqrMagnitude <= minDistanceForTarget;
    }

    public Vector2 SetDirection(float targetPosition)
    {
        if (_transform.position.x < targetPosition)
        {
            return Vector2.right;
        }

        return Vector2.left;
    }
}