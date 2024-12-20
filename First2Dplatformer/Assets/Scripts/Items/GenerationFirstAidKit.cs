using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GenerationFirstAidKit : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointsSpots;
    [SerializeField] private FirstAidKit _item;
    [SerializeField] private int _count;

    public void Init()
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
        if (_count > _pointsSpots.Count)
        {
            return _pointsSpots.Count;
        }

        return _count;
    }
}