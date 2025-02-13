using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private ItemSpawner _itemSpawner;
    [SerializeField] private FirstAidKitGeneration _generationPositionItem;

    private void Awake()
    {
        _player.Init();
        InitEnemys();
        _itemSpawner.Init();
        _generationPositionItem.Init();
    }

    private void InitEnemys()
    {
        foreach (Enemy enemy in _enemys)
        {
            enemy.Init();
        }
    }
}