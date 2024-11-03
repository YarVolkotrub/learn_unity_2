using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _hight = 10f;
    private float _timer = 5f;
    private float _delay = 1f;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = new Vector3(_startPosition.x, _startPosition.y + _hight, _startPosition.z);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(_startPosition, _endPosition, Mathf.PingPong(_timer, _delay));
        _timer += Time.deltaTime;
    }
}