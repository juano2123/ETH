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
        // Obtener la direcci�n en la que est� mirando el jugador.
        Vector2 lookDirection = GetComponent<PlayerMovement>().GetLookDirection();

        // Aseg�rate de que la direcci�n no sea cero, lo que podr�a suceder si el jugador no se ha movido.
        if (lookDirection != Vector2.zero)
        {
            // Calcular la rotaci�n basada en la direcci�n de mira.
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Instanciar la bola de fuego con la rotaci�n correcta.
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, rotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

            // Aseg�rate de que la bola de fuego tenga un Rigidbody2D antes de intentar aplicar la velocidad.
            if (rb != null)
            {
                rb.velocity = lookDirection.normalized * fireballSpeed;
            }
            else
            {
                Debug.LogError("No se encontr� Rigidbody2D en el prefab de la bola de fuego.");
            }
        }
        else
        {
            // Si lookDirection es cero, por defecto dispara hacia la derecha o en la �ltima direcci�n conocida.
            Quaternion defaultRotation = Quaternion.Euler(0, 0, 0); // Asumiendo que hacia la derecha es la direcci�n por defecto.
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, defaultRotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(fireballSpeed, 0); // Dispara hacia la derecha por defecto.
            }
            else
            {
                Debug.LogError("No se encontr� Rigidbody2D en el prefab de la bola de fuego.");
            }
        }
    }
}





