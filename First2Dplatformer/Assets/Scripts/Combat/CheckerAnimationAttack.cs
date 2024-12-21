using System;
using UnityEngine;

public class CheckerAnimationAttack : MonoBehaviour
{
    public event Action<bool> WeaponAttacking;

    public void OnAnimationWeapon()
    {
        WeaponAttacking?.Invoke(true);
    }

    public void ExitAnimationWeapon()
    {
        WeaponAttacking?.Invoke(false);
    }
}