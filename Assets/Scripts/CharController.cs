using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 3.0f;
    public float accelerateJump = 3.0f;
    private Rigidbody2D _rb; //Rigidbody of game object
    private Collider2D _cd;  // Collider of game object
    
    public GameObject leg1;
    public GameObject leg2;
    [HideInInspector]
    public bool isGrounded; 
    
    
        
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _cd = gameObject.GetComponent<Collider2D>();
        


    }

    // Update is called once per frame

    void Update()
    {
        IsTouchGround();
        Movement();
    }
    
    private void Movement()
    {
        
        if (Input.GetButtonDown("Jump") && isGrounded) //Check is pressed jump button and 2 Raycast on 2 legs.
        {

            
            print("Jump");
            _rb.velocity = new Vector2(_rb.velocity.x, 2.0f*accelerateJump);
        }

        if (Input.GetButton("Horizontal"))
        {
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rb.velocity.y);
        }

    }
    
    private void IsTouchGround()
    {
        if (IsGrounded.ItIsGrounded(leg1.transform.position) |
            IsGrounded.ItIsGrounded(leg2.transform.position))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Tube"))
        {
            print("sda");
            print("Tube");
        }
    } 
}  









    