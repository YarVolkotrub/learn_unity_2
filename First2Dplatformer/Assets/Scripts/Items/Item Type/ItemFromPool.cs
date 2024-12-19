using System;
using System.Collections;
using UnityEngine;

public class ItemFromPool : Item
{
    private float _lifeTime;

    public event Action<ItemFromPool> LifeTimeIsOver;

    public void Init(float life)
    {
        _lifeTime = life;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            StartCoroutine(ÑountdownLife());
        }

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Destroy();
        }
    }

    private IEnumerator ÑountdownLife()
    {
        WaitForSeconds wait = new(_lifeTime);

        while (true)
        {
            yield return wait;

            Destroy();
        }
    }

    public override void Destroy()
    {
        LifeTimeIsOver?.Invoke(this);
    }
}