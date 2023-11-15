using UnityEngine;

public class LanzamientoFuego : MonoBehaviour
{
    public GameObject fireballPrefab; // Prefab de la bola de fuego
    public Transform firePoint; // Punto desde donde se dispara la bola de fuego
    public float fireballSpeed = 5f; // Velocidad de la bola de fuego
    public float fireRate = 0.2f; // Balas por segundo

    private float nextFireTime = 0f; // Tiempo para el próximo disparo
    private PlayerMovement playerMovement; // Referencia al script de movimiento del jugador

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Obtener el componente PlayerMovement
    }

    // Update is called once per frame
    void Update()
    {
        // Detecta si se presiona la tecla de espacio para disparar, si el jugador está en movimiento y si ha pasado suficiente tiempo desde el último disparo.
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.IsMoving() && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            ShootFireball();
        }
    }
    void ShootFireball()
    {
        Vector2 lookDirection = playerMovement.GetLookDirection();

        if (lookDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, rotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = lookDirection.normalized * fireballSpeed;
            }
        }
    }

}





