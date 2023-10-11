using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPersoS : MonoBehaviour
{

    public float vel = 1;
    Rigidbody2D PlayerRb;
    Transform PlayerTr;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            PlayerRb.velocity = new Vector2(vel, PlayerRb.velocity.x);
            
        } else if (Input.GetKey(KeyCode.S))
        {
            PlayerRb.velocity = new Vector2(-vel, PlayerRb.velocity.x);
        } else if(Input.GetKey(KeyCode.A))
        {
            PlayerRb.velocity = new Vector2(-vel, PlayerRb.velocity.y);
        } else if(Input.GetKey(KeyCode.D))
        {
            PlayerRb.velocity = new Vector2(vel, PlayerRb.velocity.y);
        }
        
    }

}
