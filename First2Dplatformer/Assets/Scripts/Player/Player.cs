using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerPhysics))]
[RequireComponent(typeof(PlayerInventory))]
public class Player : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    private PlayerPhysics _playerPhysics;
    private PlayerInventory _playerInventory;
    private PlayerStateMachine _stateMachine;
    private Mover _mover;
    private InputSystem _inputSystem;

    public void Init()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerPhysics = GetComponent<PlayerPhysics>();
        _playerInventory = GetComponent<PlayerInventory>();

        _mover = new Mover(_playerPhysics.RigidbodyPlayer, transform);
        _inputSystem = new InputSystem();
        _stateMachine = new PlayerStateMachine(_playerAnimation, _mover, _playerPhysics, _inputSystem);
    }

    private void Start()
    {
        _stateMachine.SwitchState<PlayerIdleState>();
    }

    private void Update()
    {
        _stateMachine.Update();
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