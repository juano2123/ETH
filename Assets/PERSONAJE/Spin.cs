using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float damage = 60f;

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
