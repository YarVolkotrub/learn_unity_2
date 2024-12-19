using System;
using UnityEngine;

public class CheckerAnimationAttack : MonoBehaviour
{
    public event Action<bool> IsWeaponAttack;

    public void OnAnimationWeapon()
    {
        IsWeaponAttack?.Invoke(true);
    }

    public void ExitAnimationWeapon()
    {
        IsWeaponAttack?.Invoke(false);
    }
}