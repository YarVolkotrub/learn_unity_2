using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private GemSpawner _itemSpawner;
    [SerializeField] private FirstAidKitGenerator _generationPositionItem;

    private void Awake()
    {
        _player.Initialization();
        InitEnemys();
        _itemSpawner.Initialization();
        _generationPositionItem.Initialization();
    }

    private void InitEnemys()
    {
        foreach (Enemy enemy in _enemys)
        {
            enemy.Initialization();
        }
    }
}