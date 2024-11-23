using UnityEngine;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _move = "Moving";
    private string _idle = "Idle";

    public void Move()
    {
        _animator.SetTrigger(_move);
    }

    public void Idle()
    {
        _animator.SetTrigger(_idle);
    }
}