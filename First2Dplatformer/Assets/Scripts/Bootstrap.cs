using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Officer _officer;
    [SerializeField] private Cutthroat _cutthroat;
    [SerializeField] private ItemSpawner _itemSpawner;

    private void Awake()
    {
        _player.Init();
        _officer.Init();
        _cutthroat.Init();
        _itemSpawner.Init();
    }
}
