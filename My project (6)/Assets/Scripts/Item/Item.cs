using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _cost;
    public int Cost => _cost;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}