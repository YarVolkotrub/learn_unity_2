using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour, IPlayerAnimation
{
    [SerializeField] private Animator _animator;

    private string _move = "Moving";
    private string _jump = "Jumping";
    private string _fall = "Falling";
    private string _idle = "Idle";
    private string _meleeAttack = "MeleeAttack";

    public float Lenght => _animator.GetCurrentAnimatorStateInfo(0).length;

    public void Move()
    {
        _animator.SetTrigger(_move);
    }

    public void Jump()
    {
        _animator.SetTrigger(_jump);
    }

    public void Fall()
    {
        _animator.SetTrigger(_fall);
    }

    public void Idle()
    {
        _animator.SetTrigger(_idle);
    }

    public void Attack()
    {
        _animator.SetTrigger(_meleeAttack);
    }
}