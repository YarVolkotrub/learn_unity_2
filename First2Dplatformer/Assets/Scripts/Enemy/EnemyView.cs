using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private float _distance = 5f;

    public void SeachPlayer(Vector2 direction)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, direction, _distance, LayerMask.GetMask("Player"));

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.gameObject.tag == "Player")
            {
                Debug.Log("Hit Hit");
            }
        }
    }
}