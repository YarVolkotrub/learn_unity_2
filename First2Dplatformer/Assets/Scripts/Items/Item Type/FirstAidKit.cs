using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int _healPoint = 30;

    public int HealPoint => _healPoint;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}