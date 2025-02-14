using System;
using UnityEngine;

public class CheckerAnimationAttack : MonoBehaviour
{
    public event Action StartAttack;
    public event Action StopAttack;

    public void OnAnimationWeapon()
    {
        StartAttack?.Invoke();
    }

    public void ExitAnimationWeapon()
    {
        StopAttack?.Invoke();
    }
}