using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int Damage = 30;

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}