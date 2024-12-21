public interface IEnemyAnimator
{
    public float Lenght { get; }
    public void Move();
    public void Idle();
    public void Attack();
}