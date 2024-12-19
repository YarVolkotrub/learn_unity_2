using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour, IEnemyAnimation
{
    [SerializeField] private Animator _animator;

    private string _move = "Moving";
    private string _idle = "Idle";
    private string _attack = "Attack";

    public float Lenght => _animator.GetCurrentAnimatorStateInfo(0).length;

    public void Move()
    {
        _animator.SetTrigger(_move);
    }

    public void Idle()
    {
        _animator.SetTrigger(_idle);
    }

    public void Attack()
    {
        _animator.SetTrigger(_attack);
    }
}