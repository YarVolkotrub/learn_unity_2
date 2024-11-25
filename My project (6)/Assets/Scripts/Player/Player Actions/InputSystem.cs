using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public float MoveDirection => Input.GetAxis("Horizontal");
    public float JumpDirection => Input.GetAxis("Jump");
    public bool Stay => Input.GetButtonUp("Horizontal");
}