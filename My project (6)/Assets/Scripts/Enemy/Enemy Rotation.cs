using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class EnemyRotation : MonoBehaviour
{
    private float _currentPosition = 0;
    private float _right = 180;
    private float _left = 0;

    [SerializeField] private EnemyPatrol direction;

    private void OnEnable()
    {
        direction.Rotation += Flip;
    }

    private void OnDisable()
    {
        direction.Rotation -= Flip;
    }

    private void Flip(float direction)
    {
        if (_currentPosition == direction)
        {
            return;
        }

        Vector2 rotate = transform.eulerAngles;

        if (_currentPosition > direction)
        {
            rotate.y = _right;
        }
        else if (_currentPosition < direction)
        {
            rotate.y = _left;
        }

        transform.rotation = Quaternion.Euler(rotate);
    }
}
