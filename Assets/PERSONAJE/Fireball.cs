using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage = 25f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Aseg�rate de que el enemigo tenga el tag "Enemy"
        {
            int damage = 20; // El da�o que la bola de fuego har� al enemigo
            collision.GetComponent<FollowAI>().TakeDamage(damage);
            Destroy(gameObject); // Destruye la bola de fuego despu�s de golpear al enemigo
        }
    }

}

