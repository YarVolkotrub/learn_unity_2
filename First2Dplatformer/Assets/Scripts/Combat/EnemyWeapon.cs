using UnityEngine;

public class EnemyWeapon : Weapon
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(Damage);
        }
    }
}