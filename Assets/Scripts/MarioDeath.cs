using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioDeath : MonoBehaviour
{
    
    // Start is called before the first frame update
    private Animator _animator;
    private Rigidbody2D _rb;
    private Collider2D _cd;
    private Collider2D _cd2;
    void Start()
    {
        _cd2 = gameObject.GetComponent<CapsuleCollider2D>();
        _cd = gameObject.GetComponent<BoxCollider2D>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        IEnumerator Wait3()
        {
            yield return new WaitForSecondsRealtime(3);
            Destroy(gameObject);
        }
        _cd2.enabled = false;
        _cd.enabled = false;
        _rb.velocity = new Vector2(0, 5);
        _animator.Play("Death");
        StartCoroutine(Wait3());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.collider.gameObject.transform.CompareTag("Enemy"))
        {
            print("Death");
            Death();
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger");
    }
}
