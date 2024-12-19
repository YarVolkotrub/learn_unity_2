using UnityEngine;

public class Combat: MonoBehaviour
{

    [SerializeField] private GameObject _meleeAttack;
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
            _meleeAttack.SetActive(true);
        }
        else
        {
            _meleeAttack.SetActive(false);
        }
    }
}