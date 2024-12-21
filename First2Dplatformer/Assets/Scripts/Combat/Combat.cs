using UnityEngine;

public class Combat: MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CheckerAnimationAttack _checkerAnimationAttack;

    public void OnEnable()
    {
        _checkerAnimationAttack.WeaponAttacking += Attack;
    }

    public void OnDisable()
    {
        _checkerAnimationAttack.WeaponAttacking -= Attack;
    }

    private void Attack(bool isAttack)
    {
        _weapon.SetActive(isAttack);
    }
}