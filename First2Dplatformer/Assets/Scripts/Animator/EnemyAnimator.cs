using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour, IEnemyAnimator
{
    [SerializeField] private Animator _animator;

    private int _moveId;
    private int _idleId;
    private int _attackId;

    public float Lenght => _animator.GetCurrentAnimatorStateInfo(0).length;

    public void Init()
    {
        IEnemyAnimatorData AnimatorData = new AnimatorData();

        _moveId = AnimatorData.Move;
        _idleId = AnimatorData.idle;
        _attackId = AnimatorData.Attack;
    }

    public void Move()
    {
        _animator.SetTrigger(_moveId);
    }

    public void Idle()
    {
        _animator.SetTrigger(_idleId);
    }

    public void Attack()
    {
        _animator.SetTrigger(_attackId);
    }
}