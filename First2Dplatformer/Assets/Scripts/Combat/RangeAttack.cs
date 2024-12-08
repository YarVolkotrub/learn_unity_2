public class RangeAttack : IAttack
{
    private IDamageData _attackData;

    public RangeAttack(IDamageData data)
    {
        _attackData = data;
    }

    public void Attack()
    {

    }
}