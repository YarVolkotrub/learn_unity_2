public class EnemyHealth : IHealth
{
    private int _health;
    private int _maxHealth;

    public EnemyHealth(int health)
    {
        _health = health;
        _maxHealth = health;
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