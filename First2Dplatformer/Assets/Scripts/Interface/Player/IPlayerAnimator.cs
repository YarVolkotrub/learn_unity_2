public interface IPlayerAnimator
{
    public float Lenght { get; }
    public void Move();
    public void Idle();
    public void Fall();
    public void Jump();
    public void MeleeAttack();
}