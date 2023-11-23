using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWithCoin : MonoBehaviour
{
    public GameObject coin;
    public Sprite usedBlock;
    public Animation animationCoin;
    private GameObject _coinInstance;
    

    private Transform _posCoin;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("getCoin");
        if (collision.gameObject.CompareTag("Player"))
        {
            GetCoin();
            gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = usedBlock;
            animationCoin.Play();
            StartCoroutine(DestroyCoin());

            IEnumerator DestroyCoin()
            {
                yield return new WaitWhile(() => animationCoin.isPlaying);
                Destroy(animationCoin.gameObject);
            }
            
            
            

        }
    }
    
    private void GetCoin()
    {
        print("Coin + 1");
    }
    
}
