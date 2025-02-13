public class Health : IHeal, IHealth
{
    private int _maxHealth;

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
    }

    public void Heal(int healPoint)
    {
        HealthProperty += healPoint;

        if (HealthProperty > _maxHealth)
        {
            HealthProperty = _maxHealth;
        }
    }
}