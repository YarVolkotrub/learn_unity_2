using UnityEngine;

public class AnimatorData : IPlayerAnimatorData, IEnemyAnimatorData
{
    private string _move = "Moving";
    private string _jump = "Jumping";
    private string _fall = "Falling";
    private string _idle = "Idle";
    private string _meleeAttack = "MeleeAttack";
    private string _attack = "Attack";

    public int Move => Animator.StringToHash(_move);
    public int Jump => Animator.StringToHash(_jump);
    public int Fall => Animator.StringToHash(_fall);
    public int idle => Animator.StringToHash(_idle);
    public int MeleeAttack => Animator.StringToHash(_meleeAttack);
    public int Attack => Animator.StringToHash(_attack);
}