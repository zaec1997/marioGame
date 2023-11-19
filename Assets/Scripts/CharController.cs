using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 3.0f;
    public float accelerateJump = 3.0f;
    private Rigidbody2D _rb;
    private Collider2D _cd;
    private bool _isGrounded;
    
    
    public bool isGrounded() { return _isGrounded;}
        
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _cd = gameObject.GetComponent<Collider2D>();
        


    }

    // Update is called once per frame

    void Update()
    {
        Movement();  
        
    }
    
    private void Movement()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            print("Jump");
            _rb.velocity = new Vector2(_rb.velocity.x, 2.0f*accelerateJump);
        }

        if (Input.GetButton("Horizontal"))
        {
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rb.velocity.y);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
        
        
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }





    }
