using System.Collections.Generic;
using UnityEngine;

public class FirstAidKitGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointsSpots;
    [SerializeField] private FirstAidKit _item;
    [SerializeField] private int _count;

    public void Initialization()
    {
        if ((_pointsSpots.Count == _count) || (GetCount() == _pointsSpots.Count))
        {
            foreach (Transform point in _pointsSpots)
            {
                Instantiate(_item, point.transform.position, Quaternion.identity);
            }
        }
        else
        {
            int numberPoint;

            for (int i = 0; i < GetCount(); i++)
            {
                numberPoint = Random.Range(0, _pointsSpots.Count);
                Instantiate(_item, _pointsSpots[numberPoint].transform.position, Quaternion.identity);
                _pointsSpots.RemoveAt(numberPoint);
            }
        }
    }

    private int GetCount()
    {
        return _count > _pointsSpots.Count ? _pointsSpots.Count : _count;
    }
}