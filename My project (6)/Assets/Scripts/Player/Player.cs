using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class Player : MonoBehaviour
{
    private PlayerInventory _playerInventory;

    private void Awake()
    {
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            _playerInventory.AddItem(item);
            item.Destroy();
        }
    }
}