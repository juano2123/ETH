using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float damage = 60f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Aseg�rate de que el enemigo tenga el tag "Enemy"
        {
            int damage = 50; // El da�o que la remolino de fuego har� al enemigo
            collision.GetComponent<FollowAI>().TakeDamage(damage);
            Destroy(gameObject); // Destruye la bola de fuego despu�s de golpear al enemigo
        }
    }

}
