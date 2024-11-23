using UnityEngine;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _move = "Moving";
    private string _jump = "Jumping";
    private string _fall = "Falling";
    private string _idle = "Idle";

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
}