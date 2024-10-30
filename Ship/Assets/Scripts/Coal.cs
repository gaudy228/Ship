using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour
{
    private bool isFly = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFly)
        {
            transform.Translate(-Vector3.up * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Topka"))
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            isFly = true;
        }
        if (collision.gameObject.CompareTag("StarterCoal"))
        {
            Destroy(gameObject);
        }
    }
}
