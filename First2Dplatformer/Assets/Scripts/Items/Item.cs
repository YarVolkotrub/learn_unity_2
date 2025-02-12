using UnityEngine;

public abstract class Item : MonoBehaviour, ICollectible
{
    [SerializeField] protected int _countPoint;

    public int CountPoint => _countPoint;

    public abstract void Destroy();
}