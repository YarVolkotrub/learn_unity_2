public interface IEnemyCombat
{
    public float DistanceAttack { get; }
    public float DelayAttack { get; }
    public ITarget Target { get; }
}