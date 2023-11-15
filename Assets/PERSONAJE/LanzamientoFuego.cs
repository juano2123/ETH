using UnityEngine;

using System.Security.Cryptography;
using UnityEngine;

public class LanzamientoFuego : MonoBehaviour
{
    public GameObject PrefabFuego; // Prefab del remolino
    public Transform firePoint; // Punto desde donde se lanza el remolino
    public float FuegoSpeed = 5f; // Velocidad del remolino
    public float tiempoEntreFuegos = 0.1f;

    public float tiempoProximoFuego = 0f;

    // Update se llama una vez por frame
    void Update()
    {
        // Verifica si se presiona la tecla 'Z' y si ha pasado el tiempo suficiente desde el �ltimo lanzamiento.
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= tiempoProximoFuego)
        {
            ShootRemolino();
            tiempoProximoFuego = Time.time + tiempoEntreFuegos;
            // Establece el pr�ximo tiempo permitido para lanzar otro remolino
        }
    }

    void ShootRemolino()
    {
        // Obtener la direcci�n en la que est� mirando el jugador.
        Vector2 lookDirection = GetComponent<PlayerMovement>().GetLookDirection();

        // Aseg�rate de que la direcci�n no sea cero, lo que podr�a suceder si el jugador no se ha movido.
        if (lookDirection != Vector2.zero)
        {
            // Calcular la rotaci�n basada en la direcci�n de mira.
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Instanciar el remolino con la rotaci�n correcta.
            GameObject Fuego = Instantiate(PrefabFuego, firePoint.position, rotation);
            Rigidbody2D rb = Fuego.GetComponent<Rigidbody2D>();

            // Aseg�rate de que el remolino tenga un Rigidbody2D antes de intentar aplicar la velocidad.
            if (rb != null)
            {
                rb.velocity = lookDirection.normalized * FuegoSpeed;
            }
            else
            {
                Debug.LogError("No se encontr� Rigidbody2D en el prefab del remolino.");
            }
        }
        else
        {
            // Si lookDirection es cero, por defecto lanza hacia la derecha o en la �ltima direcci�n conocida.
            Quaternion defaultRotation = Quaternion.Euler(0, 0, 0); // Asumiendo que hacia la derecha es la direcci�n por defecto.
            GameObject Fuego = Instantiate(PrefabFuego, firePoint.position, defaultRotation);
            Rigidbody2D rb = Fuego.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(FuegoSpeed, 0); // Lanza hacia la derecha por defecto.
            }
            else
            {
                Debug.LogError("No se encontr� Rigidbody2D en el prefab del remolino.");
            }
        }
    }
}




