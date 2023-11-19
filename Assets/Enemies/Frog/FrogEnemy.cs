using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class FrogEnemy : MonoBehaviour
{
    public float speed = 0.1f;
    private Rigidbody2D _rigidbody2D;
    private int _direction = 1;
    public float distanceToWall = 1.1f;
    private Vector2 _startRayPosRight;
    private Vector2 _startRayPosLeft;

    

    public float widthStartRaycast = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

        _rigidbody2D = gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        _rigidbody2D.velocity = new Vector2(speed * _direction, _rigidbody2D.velocity.y);
        


    }

    void FixedUpdate()
    {
        _startRayPosRight = new Vector2(transform.position.x + widthStartRaycast, transform.position.y);
        _startRayPosLeft = new Vector2(transform.position.x - widthStartRaycast, transform.position.y);
        RaycastHit2D hitRight = Physics2D.Raycast(_startRayPosRight, Vector2.right, distanceToWall);
        RaycastHit2D hitLeft = Physics2D.Raycast(_startRayPosLeft, Vector2.left, distanceToWall);
        
        Debug.DrawRay(_startRayPosRight, Vector2.right * distanceToWall, Color.blue, 0.2f);
        Debug.DrawRay(_startRayPosLeft, Vector2.left * distanceToWall, Color.red, 0.2f);

        try
        {
            if (hitRight.collider.gameObject.CompareTag("Ground"))
            {
                print("hitRight");
                _direction *= -1;
            }
            if (hitLeft.collider.gameObject.CompareTag("Ground"))
            {
                print("hitLeft");
                _direction *= -1;
            }
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("ERROR");
        }


    }


   




private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(other.gameObject.GetComponent<Rigidbody2D>().velocity.x, 2);
            print("Kill");
            gameObject.transform.parent.gameObject.transform.position =
                new Vector3(transform.position.x, transform.position.y - 0.05f);
            gameObject.transform.parent.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("body").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("sprite_anim").GetComponent<Animator>().Play("death");
            
            StartCoroutine(WaitAndDestroy());
            
        }
    }


    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
