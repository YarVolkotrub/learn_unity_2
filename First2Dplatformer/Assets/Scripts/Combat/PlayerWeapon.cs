using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private int _damage = 30;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}