using UnityEngine;

public class Enemy_Farmer : Enemies
{
    [Header("Attack Parameters")]
    [SerializeField] private int _damage = 15;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bomb>(out Bomb bomb))
        {
            Destroy(this.gameObject);
            Destroy(bomb.gameObject);

            Die();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player_Health>(out Player_Health player))
        {
            player.TakeDamage(_damage);

            Attack();
        }
    }
}