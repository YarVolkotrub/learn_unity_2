using UnityEngine;

public class Health : IHeal, IDamagable
{
    private int _maxHealth;
    private int _minHealth = 0;

    public int HealthProperty { get; private set; }

    public Health(int health)
    {
        HealthProperty = health;
        _maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }

        HealthProperty -= damage;

        NormalizationHealth();
    }

    public void Heal(int healPoint)
    {
        HealthProperty += healPoint;

        NormalizationHealth();
    }

    private void NormalizationHealth()
    {
        HealthProperty = Mathf.Clamp(HealthProperty, _minHealth, _maxHealth);
    }
}