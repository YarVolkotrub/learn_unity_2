using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private int _damage = 30;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}