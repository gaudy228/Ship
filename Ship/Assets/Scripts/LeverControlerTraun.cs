using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControlerTraun : MonoBehaviour
{
    private bool canMove = false;
    private Rigidbody2D rb;
    [SerializeField] private float speedMoveLever;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canMove)
        {
           rb.velocity = new Vector2(speedMoveLever, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canMove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canMove = false;
            rb.velocity = Vector2.zero;
        }
    }
}
