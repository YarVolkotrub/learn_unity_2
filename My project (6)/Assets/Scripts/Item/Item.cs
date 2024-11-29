using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _cost;
    private ItemPool _pool;
    private float _lifeTime;

    public int Cost => _cost;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.otherCollider.TryGetComponent(out Player player))
        //if (collision.gameObject.TryGetComponent(out Player player))
        //{

        //    Debug.Log("AAAAAAAA");
        //    Return();
        //}

        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            StartCoroutine(ÑountdownLife());
        }
    }

    public void Init(ItemPool pool, float life)
    {
        _pool = pool;
        _lifeTime = life;
    }

    public void Destroy()
    {
        if (_pool != null)
        {
            _pool.Return(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator ÑountdownLife()
    {
        WaitForSeconds wait = new(_lifeTime);

        while (true)
        {
            yield return wait;

            this.Destroy();
        }
    }
}