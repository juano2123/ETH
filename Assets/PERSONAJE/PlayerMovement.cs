using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lookDirection = Vector2.right; // Direcci�n inicial en la que el personaje est� mirando
    private Animator animator;

    // Inicializaci�n
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Actualizaci�n de la entrada del usuario
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            lookDirection = movement; // Actualiza la direcci�n de mira basada en el movimiento
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Actualizaci�n de la f�sica
    void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Funci�n p�blica para obtener la direcci�n de mira
    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }
}
