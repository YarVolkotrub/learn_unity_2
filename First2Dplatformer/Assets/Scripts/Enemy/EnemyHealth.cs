using UnityEngine;

public class EnemyHealth : IEnemyHealth
{
    [SerializeField] private int _health = 100;
    private int _maxHealth;

    public void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }

        _health -= damage;
    }
}