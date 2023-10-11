using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class newMovPersoS : MonoBehaviour
{

    private Rigidbody2D perRB;
    private float Horizontal, Vertical;
    public float arriba = 1;
    public float Speed = 1;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        perRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetBool("running", false);

         if (Input.GetKeyDown(KeyCode.W))
        {
            perRB.AddForce(Vector2.up*arriba);
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            perRB.AddForce(Vector2.down * arriba);
        }

    }

    private void FixedUpdate()
    {
        perRB.velocity = new Vector2 (Horizontal, perRB.velocity.y);
        
    }
}
