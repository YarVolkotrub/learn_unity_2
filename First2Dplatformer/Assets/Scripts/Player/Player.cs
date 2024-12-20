using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour, ITarget, IHealth
{
    [SerializeField] private int _maxHealthPoint = 100;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerPhysics _playerPhysics;

    private IPlayerInventory _playerInventory;
    private IMover _mover;
    private IInputSystem _inputSystem;
    private IHealth _health;
    private IHeal _heal;
    private PlayerMovingStateMachine _stateMachine;

    public Vector2 Position => transform.position;

    public void Init()
    {
        PlayerHealth health = new(_maxHealthPoint);
        _heal = health;
        _health = health;

        _playerInventory = new PlayerInventory();
        _mover = new PlayerMover(_playerPhysics.RigidbodyPlayer, transform);
        _inputSystem = new InputReader();
        _stateMachine = new PlayerMovingStateMachine(_playerAnimation, _mover, _playerPhysics, _inputSystem);
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
        else if (collider.gameObject.TryGetComponent(out FirstAidKit firstAidKit))
        {
            _heal.Heal(firstAidKit.HealPoint);
            firstAidKit.Destroy();
        }
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}