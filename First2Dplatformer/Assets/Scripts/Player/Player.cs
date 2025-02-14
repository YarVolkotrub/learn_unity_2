using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour, ITarget, IDamagable
{
    [SerializeField] private int _maxHealthPoint = 100;
    [SerializeField] private PlayerAnimator _Animator;
    [SerializeField] private PlayerPhysics _Physics;

    private IPlayerInventory _inventory;
    private IDamagable _health;
    private IHeal _heal;
    private StateMachine _stateMachine;

    public Vector2 Position => transform.position;

    public void Initialization()
    {
        Health health = new(_maxHealthPoint);
        IPlayerAnimator _animator = _Animator;
        _heal = health;
        _health = health;
        _Animator.Init();
        _inventory = new PlayerInventory();
        IMover _mover = new PlayerMover(_Physics.RigidbodyPlayer, transform);
        IInputSystem _inputSystem = new InputReader();
        _stateMachine = new StateMachine(_animator, _mover, _Physics, _inputSystem);
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
        if (collider.gameObject.TryGetComponent(out ICollectible item))
        {
            if (item is FirstAidKit)
            {
                _heal.Heal(item.CountPoint);
            }
            else
            {
                _inventory.AddPoints(item.CountPoint);
            }

            item.Collecte();
        }
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}