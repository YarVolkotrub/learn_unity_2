using UnityEngine;

public class EnemyView : IEnemyView
{
    private Vector2 _direction = Vector2.right;
    private float _distance = 3f;
    private string _layerPlayer = "Player";

    public float Distance => _distance;
    public Vector2 Direction => _direction;

    public bool IsSeachPlayer(Vector2 position, Vector2 direction)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(position, direction, _distance, LayerMask.GetMask(_layerPlayer));

        if (raycastHit2D.collider != null)
        {
            return true;
        }

        return false;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}