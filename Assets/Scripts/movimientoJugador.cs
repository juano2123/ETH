using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    //Movimiento de personaje 
    private Rigidbody2D rb2D;
    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    //Salto de personaje
    [Header("salto")]
    [SerializeField] private float fuerzaDeSalto = 10f;
    [SerializeField] private LayerMask Suelo;
    [SerializeField] private Transform controlSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    private float tiempoDeSalto;
    [SerializeField] private float tiempoMaximoDeSalto = 0.5f;
    [SerializeField] private float fuerzaInicialDeSalto = 10f; // Ajusta el valor inicial de la fuerza de salto según tus necesidades
    [SerializeField] private float fuerzaMaximaDeSalto = 20f; // Ajusta el valor máximo de la fuerza de salto según tus necesidades


    //Animacion
    [Header("Animacion")]
    private Animator animator; 

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }


    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            tiempoDeSalto = Time.time;
            salto = true;
        }

        if (Input.GetButton("Jump") && salto)
        {
            float tiempoTranscurrido = Time.time - tiempoDeSalto;
            float factorDeFuerza = Mathf.Clamp(tiempoTranscurrido / tiempoMaximoDeSalto, 0f, 1f);
            float fuerzaDeSaltoActual = Mathf.Lerp(fuerzaInicialDeSalto, fuerzaMaximaDeSalto, factorDeFuerza);

            // Aplica la fuerza de salto calculada
            rb2D.AddForce(Vector2.up * fuerzaDeSaltoActual);
        }

        // Restringe la duración del salto
        if (Input.GetButtonUp("Jump"))
        {
            salto = false;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controlSuelo.position, dimensionesCaja, 0f, Suelo);
        animator.SetBool("enSuelo", enSuelo);
        //Movimiento
        Movimiento(movimientoHorizontal * Time.fixedDeltaTime, salto);
        salto = false; 

    }

    private void Movimiento(float movimiento, bool salto)
    {
        Vector3 velocidadObjetivo = new Vector2(movimiento, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (movimiento > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if(movimiento < 0 && mirandoDerecha)
        {
            Girar();
        }
        if (enSuelo && salto)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }


    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(controlSuelo.position, dimensionesCaja);
    }
}
