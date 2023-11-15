using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private int health = 100; // Salud inicial del enemigo

    private bool isFacingRight = true;

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            Attack();
        }

        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }

    private void Attack()
    {
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
            }
            else
            {
                Debug.LogError("No se encontró el componente PlayerHealth en el jugador.");
            }
        }
        else
        {
            Debug.LogError("La variable 'player' no está asignada en FollowAI.");
        }
    }


    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    // Método para manejar el daño recibido
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemigo recibe daño: " + damage + ". Salud restante: " + health);

        // Si la salud llega a 0, destruir al enemigo
        if (health <= 0)
        {
            Debug.Log("Enemigo derrotado");
            Destroy(gameObject);
        }
    }


}
