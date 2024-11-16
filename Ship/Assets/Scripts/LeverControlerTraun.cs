using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControlerTraun : MonoBehaviour
{
    public float currendSpeed = 1.0f;
    public bool stop;
    public bool goLeft;
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LR"))
        {
            currendSpeed = 1;
        }
        if (collision.gameObject.CompareTag("LR05"))
        {
            currendSpeed = 0.5f;
            stop = false;
            
        }
        if (collision.gameObject.CompareTag("LS"))
        {
            stop = true;
            goLeft = false;
            currendSpeed = 0;
        }
        if (collision.gameObject.CompareTag("LL"))
        {
            stop = true;
            goLeft = true;
        }

    }
    
}
