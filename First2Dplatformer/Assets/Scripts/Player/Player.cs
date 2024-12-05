using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour, ITarget
{
    [SerializeField, Range(1, 100)] private int _health;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerPhysics _playerPhysics;
    private PlayerInventory _playerInventory;
    private PlayerStateMachine _stateMachine;
    private PlayerMover _mover;
    private InputSystem _inputSystem;

    public Vector2 Position => transform.position;

    public void Init()
    {
        _playerInventory = new PlayerInventory();
        _mover = new PlayerMover(_playerPhysics.RigidbodyPlayer, transform);
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

        if (_inputSystem.IsAttack)
        {
            _playerAnimation.Attack();
        }
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

    public void TakeDamage(int damage)
    {

    }
}