using UnityEngine;

public class LanzamientoSpin : MonoBehaviour
{
    public GameObject SpinPrefab; // Prefab del remolino
    public Transform firePoint; // Punto desde donde se dispara el remolino
    public float spinSpeed = 5f; // Velocidad del remolino
    public float tiempoEntreRemolinos = 1f; // Tiempo de espera entre lanzamientos de remolinos

    private float tiempoProximoRemolino = 0f;

    // Update se llama una vez por frame
    void Update()
    {
        // Verifica si se presiona la tecla 'Z' y si ha pasado el tiempo suficiente desde el último lanzamiento.
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= tiempoProximoRemolino)
        {
            ShootSpin();
            tiempoProximoRemolino = Time.time + tiempoEntreRemolinos; // Establece el próximo tiempo permitido para lanzar otro remolino
        }
    }

    void ShootSpin()
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
            GameObject spin = Instantiate(SpinPrefab, firePoint.position, rotation);
            Rigidbody2D rb = spin.GetComponent<Rigidbody2D>();

            // Asegúrate de que el remolino tenga un Rigidbody2D antes de intentar aplicar la velocidad.
            if (rb != null)
            {
                rb.velocity = lookDirection.normalized * spinSpeed;
            }
            else
            {
                Debug.LogError("No se encontró Rigidbody2D en el prefab del remolino.");
            }
        }
        else
        {
            // Si lookDirection es cero, por defecto dispara hacia la derecha o en la última dirección conocida.
            Quaternion defaultRotation = Quaternion.Euler(0, 0, 0); // Asumiendo que hacia la derecha es la dirección por defecto.
            GameObject spin = Instantiate(SpinPrefab, firePoint.position, defaultRotation);
            Rigidbody2D rb = spin.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(spinSpeed, 0); // Dispara hacia la derecha por defecto.
            }
            else
            {
                Debug.LogError("No se encontró Rigidbody2D en el prefab del remolino.");
            }
        }
    }
}

