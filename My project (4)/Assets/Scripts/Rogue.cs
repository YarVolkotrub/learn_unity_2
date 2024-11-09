using UnityEngine;

public class Rogue : MonoBehaviour
{
    private Vector3 _startPosition; 
    private Vector3 _endPosition;
    private float _delay = 2f;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = new(0, 5, 0);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float time = Mathf.PingPong(Time.time, _delay);
        transform.position = Vector3.Lerp(_startPosition, _endPosition, time);
    }
}
