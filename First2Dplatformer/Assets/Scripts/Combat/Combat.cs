using UnityEngine;

public class Combat: MonoBehaviour
{

    [SerializeField] private Weapon _weapon;
    [SerializeField] private CheckerAnimationAttack _checkerAnimationAttack;

    public void OnEnable()
    {
        _checkerAnimationAttack.IsWeaponAttack += Attack;
    }

    public void OnDisable()
    {
        _checkerAnimationAttack.IsWeaponAttack -= Attack;
    }

    private void Attack(bool isAttack)
    {
        if (isAttack)
        {
            _weapon.SetActive(true);
        }
        else
        {
            _weapon.SetActive(false);
        }
    }
}