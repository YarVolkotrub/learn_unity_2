using UnityEngine;

public class Friend : MonoBehaviour
{

    [SerializeField] private Transform _rotationCenter;
    private Vector3 _offset;
    private float _speed = 30f;

    private void Start()
    {
        _offset = transform.position - _rotationCenter.position;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = _rotationCenter.position + _offset;
        transform.RotateAround(_rotationCenter.position, Vector3.up, _speed * Time.deltaTime);
        _offset = transform.position - _rotationCenter.position;
    }
}
