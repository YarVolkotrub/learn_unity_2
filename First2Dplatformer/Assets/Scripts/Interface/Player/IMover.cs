using UnityEngine;

public interface IMover
{
    public void Move(float directionAxisX, float speed, float directionAxisY);
    public void Jump(float directionAxisY, float speed);
    public void Stand();
    public void Flip(Vector2 direction);
}