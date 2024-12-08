public class Weapon
{
    private AttackData _attackData;
    public float _delay;

    public bool IsUse { get; private set; }

    public Weapon(AttackData attackData, float delay)
    {
        _attackData = attackData;
        _delay = delay;
    }
}