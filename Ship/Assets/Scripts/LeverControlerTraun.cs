using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControlerTraun : MonoBehaviour
{
    public float currendSpeed = 0f;
    public bool stop;
    public bool goLeft;
    public bool goRight;
    public bool goHalfRight;
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
            
            goRight = true;
            goHalfRight = false;
        }
        if (collision.gameObject.CompareTag("LR05"))
        {
            
            goHalfRight = true;
            goRight = false;
            stop = false;
            
        }
        if (collision.gameObject.CompareTag("LS"))
        {
            goHalfRight = false;
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
