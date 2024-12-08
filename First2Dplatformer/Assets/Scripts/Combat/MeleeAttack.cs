public class MeleeAttack : IAttack
{
    private IDamageData _attackData;

    public MeleeAttack(IDamageData data)
    {
        _attackData = data;
    }

    public void Attack()
    {

    }
}