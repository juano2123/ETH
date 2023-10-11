using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Salud máxima del jugador
    private int currentHealth;  // Salud actual del jugador

    void Start()
    {
        currentHealth = maxHealth; // Inicializamos la salud del jugador al máximo al comenzar el juego
    }

    // Método para recibir daño
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reducimos la salud del jugador

        // Verificamos si la salud del jugador ha llegado a 0 o menos
        if (currentHealth <= 0)
        {
            Die(); // Llamamos al método para "matar" al jugador
        }
    }

    // Método que se ejecuta cuando el jugador muere
    private void Die()
    {
        Debug.Log("El jugador ha muerto");
        // Aquí puedes agregar lógica adicional, como mostrar una pantalla de "Game Over", reiniciar el nivel, etc.
    }
}

