using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool ItIsGrounded(Vector2 pos)
    {
        RaycastHit2D isGrounded = Physics2D.Raycast(pos, Vector2.down, 0.25f);
        Debug.DrawRay(pos, Vector2.down*0.25f, Color.red, 10.0f);
        if (!ReferenceEquals(isGrounded.transform, null))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
