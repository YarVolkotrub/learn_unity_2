using UnityEngine;

public class InputReader : IInputSystem
{
    private float _neutralPositionAxis = 0f;
    private string _horizontal = "Horizontal";
    private string _jump = "Jump";
    private string _attack = "Fire2";

    public Vector2 MoveDirection => new(Input.GetAxisRaw(_horizontal), _neutralPositionAxis);
    public Vector2 JumpDirection => new(_neutralPositionAxis, Input.GetAxisRaw(_jump));
    public bool IsStay => Input.GetButtonUp(_horizontal);
    public bool IsMeleeAttack => Input.GetButtonDown(_attack);
}