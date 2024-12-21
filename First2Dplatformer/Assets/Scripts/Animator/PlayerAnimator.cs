using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
{
    [SerializeField] private Animator _animator;

    private int _moveId;
    private int _jumpId;
    private int _fallId;
    private int _idleId;
    private int _meleeAttackId;

    public float Lenght => _animator.GetCurrentAnimatorStateInfo(0).length;

    public void Init()
    {
        IPlayerAnimatorData AnimatorData = new AnimatorData();

        _moveId = AnimatorData.Move;
        _jumpId = AnimatorData.Jump;
        _fallId = AnimatorData.Fall;
        _idleId = AnimatorData.idle;
        _meleeAttackId = AnimatorData.MeleeAttack;
    }

    public void Move()
    {
        _animator.SetTrigger(_moveId);
    }

    public void Jump()
    {
        _animator.SetTrigger(_jumpId);
    }

    public void Fall()
    {
        _animator.SetTrigger(_fallId);
    }

    public void Idle()
    {
        _animator.SetTrigger(_idleId);
    }

    public void MeleeAttack()
    {
        _animator.SetTrigger(_meleeAttackId);
    }
}