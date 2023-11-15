using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aquí puedes agregar lógica para lo que sucede cuando el enemigo muere
        // Por ejemplo, reproducir una animación, eliminar el objeto, etc.
        Destroy(gameObject);
    }
}

