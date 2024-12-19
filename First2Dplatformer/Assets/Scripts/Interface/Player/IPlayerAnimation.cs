public interface IPlayerAnimation
{
    public float Lenght { get; }
    public void Move();
    public void Idle();
    public void Attack();
}