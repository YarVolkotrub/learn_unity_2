using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour, ITarget
{
    [SerializeField, Range(1, 100)] private int _health;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerPhysics _playerPhysics;
    private PlayerInventory _playerInventory;
    private PlayerMovingStateMachine _stateMachine;
    private PlayerMover _mover;
    private InputReader _inputSystem;
    private PlayerCombat _playerCombat;

    public Vector2 Position => transform.position;

    public void Init()
    {
        _playerInventory = new PlayerInventory();
        _mover = new PlayerMover(_playerPhysics.RigidbodyPlayer, transform);
        _inputSystem = new InputReader();
        _stateMachine = new PlayerMovingStateMachine(_playerAnimation, _mover, _playerPhysics, _inputSystem);
        _playerCombat = new PlayerCombat(_inputSystem, _playerAnimation, _playerPhysics);
    }

    private void Start()
    {
        _stateMachine.SwitchState<PlayerIdleState>();
    }

    private void Update()
    {
        _stateMachine.Update();

        _playerCombat.Attack();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Item item))
        {
            _playerInventory.AddPoints(item.Cost);
            item.Destroy();
        }
    }
}