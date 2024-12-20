using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int Damage = 30;

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            gameObject.SetActive(isActive);
        }
        else
        {
            gameObject.SetActive(isActive);
        }
    }
}