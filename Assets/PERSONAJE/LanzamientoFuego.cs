using UnityEngine;

public class LanzamientoFuego : MonoBehaviour
{
    public GameObject fireballPrefab; // Prefab de la bola de fuego
    public Transform firePoint; // Punto desde donde se dispara la bola de fuego
    public float fireballSpeed = 5f; // Velocidad de la bola de fuego

    // Update is called once per frame
    void Update()
    {
        // Detecta si se presiona la tecla de espacio para disparar, independientemente del movimiento.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        // Obtener la dirección en la que está mirando el jugador.
        Vector2 lookDirection = GetComponent<PlayerMovement>().GetLookDirection();

        // Asegúrate de que la dirección no sea cero, lo que podría suceder si el jugador no se ha movido.
        if (lookDirection != Vector2.zero)
        {
            // Calcular la rotación basada en la dirección de mira.
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Instanciar la bola de fuego con la rotación correcta.
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, rotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

            // Asegúrate de que la bola de fuego tenga un Rigidbody2D antes de intentar aplicar la velocidad.
            if (rb != null)
            {
                rb.velocity = lookDirection.normalized * fireballSpeed;
            }
            else
            {
                Debug.LogError("No se encontró Rigidbody2D en el prefab de la bola de fuego.");
            }
        }
        else
        {
            // Si lookDirection es cero, por defecto dispara hacia la derecha o en la última dirección conocida.
            Quaternion defaultRotation = Quaternion.Euler(0, 0, 0); // Asumiendo que hacia la derecha es la dirección por defecto.
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, defaultRotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(fireballSpeed, 0); // Dispara hacia la derecha por defecto.
            }
            else
            {
                Debug.LogError("No se encontró Rigidbody2D en el prefab de la bola de fuego.");
            }
        }
    }
}





