using UnityEngine;

public class InputReader : IInputSystem
{
    private float _neutralPositionAxis = 0f;

    public Vector2 MoveDirection => new(Input.GetAxisRaw("Horizontal"), _neutralPositionAxis);
    public Vector2 JumpDirection => new(_neutralPositionAxis, Input.GetAxisRaw("Jump"));
    public bool IsStay => Input.GetButtonUp("Horizontal");
    public bool IsMeleeAttack => Input.GetButtonDown("Fire2");
    public bool IsRangeAttack => Input.GetButtonDown("Fire3");
}