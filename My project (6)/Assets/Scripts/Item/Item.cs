using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected int _cost;

    public int Cost => _cost;

    public abstract void Destroy();
}