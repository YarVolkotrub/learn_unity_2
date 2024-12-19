public class PlayerHealth : IPlayerHealth
{
    private int _maxHealth;

    public int Health { get; private set; }

    public PlayerHealth(int health)
    {
        Health = health;
        _maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }

        Health -= damage;
    }

    public void Heal(int healPoint)
    {
        Health += healPoint;

        if (Health > _maxHealth)
        {
            Health = _maxHealth;
        }
    }
}