using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Vector2 MoveDirection => new(Input.GetAxis("Horizontal"), 0);
    public bool Stay => Input.GetButtonUp("Horizontal");
    //public bool Jump => Input.GetButtonDown("Jump");
    public Vector2 JumpDirection => new(0, Input.GetAxis("Jump"));
}