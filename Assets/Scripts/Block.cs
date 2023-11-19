using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    private ParticleSystem _particleSystemDestroy;
    private GameObject _block;
    // Start is called before the first frame update
    void Start()
    {
        
        _block = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyBlock()
    {
        print("destroyBlock");
        IEnumerator Wait5()
        {
            yield return new WaitForSecondsRealtime(5);
            Destroy(_block);
        }
        gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.transform.parent.gameObject.GetComponent<ParticleSystem>().Emit(25);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(Wait5());
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("entered");
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyBlock();
            
        }
    }
}
