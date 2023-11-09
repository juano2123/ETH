using System.Security.Cryptography;
using UnityEngine;

public class LanzamientoRemolino : MonoBehaviour
{
    public GameObject remolinoPrefab; // Prefab del remolino
    public Transform launchPoint; // Punto desde donde se lanza el remolino
    public float remolinoSpeed = 5f; // Velocidad del remolino
    public float tiempoEntreRemolinos = 1f;

    private float tiempoProximoRemolino = 0f;

    // Update se llama una vez por frame
    void Update()
    {
        // Verifica si se presiona la tecla 'Z' y si ha pasado el tiempo suficiente desde el último lanzamiento.
        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= tiempoProximoRemolino)
        {
            ShootRemolino();
            tiempoProximoRemolino = Time.time + tiempoEntreRemolinos; // Establece el próximo tiempo permitido para lanzar otro remolino
        }
    }

    void ShootRemolino()
    {
        // Obtener la dirección en la que está mirando el jugador.
        Vector2 lookDirection = GetComponent<PlayerMovement>().GetLookDirection();

        // Asegúrate de que la dirección no sea cero, lo que podría suceder si el jugador no se ha movido.
        if (lookDirection != Vector2.zero)
        {
            // Calcular la rotación basada en la dirección de mira.
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Instanciar el remolino con la rotación correcta.
            GameObject remolino = Instantiate(remolinoPrefab, launchPoint.position, rotation);
            Rigidbody2D rb = remolino.GetComponent<Rigidbody2D>();

            // Asegúrate de que el remolino tenga un Rigidbody2D antes de intentar aplicar la velocidad.
            if (rb != null)
            {
                rb.velocity = lookDirection.normalized * remolinoSpeed;
            }
            else
            {
                Debug.LogError("No se encontró Rigidbody2D en el prefab del remolino.");
            }
        }
        else
        {
            // Si lookDirection es cero, por defecto lanza hacia la derecha o en la última dirección conocida.
            Quaternion defaultRotation = Quaternion.Euler(0, 0, 0); // Asumiendo que hacia la derecha es la dirección por defecto.
            GameObject remolino = Instantiate(remolinoPrefab, launchPoint.position, defaultRotation);
            Rigidbody2D rb = remolino.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(remolinoSpeed, 0); // Lanza hacia la derecha por defecto.
            }
            else
            {
                Debug.LogError("No se encontró Rigidbody2D en el prefab del remolino.");
            }
        }
    }
}

