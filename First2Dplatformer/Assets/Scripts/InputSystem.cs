using UnityEngine;

public class InputSystem
{
    private float _neutralPositionAxis = 0f;
    public Vector2 MoveDirection => new(Input.GetAxisRaw("Horizontal"), _neutralPositionAxis);
    public Vector2 JumpDirection => new(_neutralPositionAxis, Input.GetAxisRaw("Jump"));
    public bool IsStay => Input.GetButtonUp("Horizontal");
}