using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage = 50f;
    public float lifetime = 1f; // Tiempo de vida del remolino en segundos

    void Start()
    {
        // Destruye el remolino después de 'lifetime' segundos
        Debug.Log("Destruyendo remolino en " + lifetime + " segundos.");
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Asegúrate de que el enemigo tenga el tag "Enemy"
        {
            int damage = 50; // El daño que la remolino de fuego hará al enemigo
            collision.GetComponent<FollowAI>().TakeDamage(damage);
            Destroy(gameObject); // Destruye la bola de fuego después de golpear al enemigo
        }
    }
}

