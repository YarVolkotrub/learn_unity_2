public class PlayerCombat: IAttack, IDamagable
{
    private Weapon _sword;
    private Weapon _pistol;
    private PlayerAnimation _playerAnimation;
    private InputReader _inputReader;
    private PlayerPhysics _playerPhysics;

    public PlayerCombat(InputReader inputReader, PlayerAnimation playerAnimation, PlayerPhysics playerPhysics)
    {
        _inputReader = inputReader;
        _playerAnimation = playerAnimation;
        _playerPhysics = playerPhysics;

        //_sword = new Weapon();
        //_pistol = new Weapon();
    }

    public void Attack()
    {
        if (_inputReader.IsMeleeAttack)
        {
            _playerAnimation.MeleeAttack();
        }

        if (_inputReader.IsRangeAttack)
        {
            _playerAnimation.RangeAttack();
        }
    }

    public void TakeDamage(IDamageData damageData)
    {

    }
}