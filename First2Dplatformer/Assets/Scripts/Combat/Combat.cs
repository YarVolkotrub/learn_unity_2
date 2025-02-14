using UnityEngine;

public class Combat: MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CheckerAnimationAttack _checkerAnimationAttack;

    public void OnEnable()
    {
        _checkerAnimationAttack.StartAttack += StartAttack;
        _checkerAnimationAttack.StopAttack += StopAttack;
    }

    public void OnDisable()
    {
        _checkerAnimationAttack.StartAttack -= StartAttack;
        _checkerAnimationAttack.StopAttack -= StopAttack;
    }

    private void StartAttack()
    {
        _weapon.Enable();
    }

    private void StopAttack()
    {
        _weapon.Disable();
    }
}