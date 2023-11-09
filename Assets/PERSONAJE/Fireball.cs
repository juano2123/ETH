using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage = 25f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Asegúrate de que el enemigo tenga el tag "Enemy"
        {
            int damage = 20; // El daño que la bola de fuego hará al enemigo
            collision.GetComponent<FollowAI>().TakeDamage(damage);
            Destroy(gameObject); // Destruye la bola de fuego después de golpear al enemigo
        }
    }

}

