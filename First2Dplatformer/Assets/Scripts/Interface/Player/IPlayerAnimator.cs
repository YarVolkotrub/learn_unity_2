public interface IPlayerAnimator
{
    public float Lenght { get; }
    public void Move();
    public void Idle();
    public void MeleeAttack();
}