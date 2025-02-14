using UnityEngine;

public abstract class Item : MonoBehaviour, ICollectible
{
    [SerializeField] private int _countPoint;

    public int CountPoint => _countPoint;

    public abstract void Collecte();
}