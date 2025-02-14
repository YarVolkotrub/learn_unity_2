using System;
using System.Collections;
using UnityEngine;

public class PooledGem : Item
{
    private float _lifeTime;

    public event Action<PooledGem> LifeTimeIsOver;

    public void Init(float life)
    {
        _lifeTime = life;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground _))
        {
            StartCoroutine(CountdownLife());
        }

        if (collision.gameObject.TryGetComponent(out Player _))
        {
            Collecte();
        }
    }

    private IEnumerator CountdownLife()
    {
        WaitForSeconds wait = new(_lifeTime);

        while (true)
        {
            yield return wait;

            Collecte();
        }
    }

    public override void Collecte()
    {
        LifeTimeIsOver?.Invoke(this);
    }
}