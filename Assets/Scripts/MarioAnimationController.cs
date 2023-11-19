using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioAnimationController : MonoBehaviour
{
    // Start is called before the first frame update 
    private CharController _charController;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _charController = gameObject.transform.parent.gameObject.GetComponent<CharController>();
        _rb = gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity.x > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetFloat("velocity.x" , _rb.velocity.x);
            
        }
        else
        {
            _spriteRenderer.flipX = true;
            _animator.SetFloat("velocity.x" , _rb.velocity.x*(-1));
        }
        _animator.SetFloat("velocity.y" , _rb.velocity.y);
        _animator.SetBool(("isGrounded") , _charController.isGrounded());
    }
}
