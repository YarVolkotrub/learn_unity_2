using UnityEngine;

public interface IInputSystem
{
    public Vector2 MoveDirection { get; }
    public Vector2 JumpDirection { get; }
    public bool IsStay { get; }
    public bool IsMeleeAttack { get; }
    public bool IsRangeAttack { get; }
}