using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private int _indexPoint;
    [SerializeField] private float _time;
    [SerializeField] private Transform _point;

    private Transform[] _pathPoints;
    
    private void Start()
    {
        _pathPoints = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _pathPoints[i] = _point.GetChild(i);
        }
    }

    private void Update()
    {
        Transform nextPoint = _pathPoints[_indexPoint];
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, _time * Time.deltaTime);

        if (transform.position == nextPoint.position)
        {
            MoveToNextPathPoint();
        }
    }

    private void MoveToNextPathPoint()
    {
        _indexPoint = ++_indexPoint % _pathPoints.Length;
        Vector3 nextPointVector = _pathPoints[_indexPoint].transform.position;
        transform.forward = nextPointVector - transform.position;
    }
}