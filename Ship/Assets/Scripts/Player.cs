using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float climbSpeed;
    private Rigidbody2D rb;
    private bool canJump = true;
    private bool canClimb = false;
    public bool isEActive = true;
    public bool isLadder = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        if (canClimb)
        {
            ClimbLadder();

        }
        
    }
    void Update()
    {
        
    }
    private void Move()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
    }
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void ClimbLadder()
    {
        if (Input.GetKey(KeyCode.E) && isEActive)
        {
            isLadder = true;
            isEActive = false;
            
        }
        if(Input.GetKey(KeyCode.E) && !isEActive)
        {
            isLadder = false;
            isEActive = true;
            rb.gravityScale = 1;
        }
        if (isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * climbSpeed);
            rb.gravityScale = 0;  
        }
        
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = false;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
            rb.gravityScale = 1;
            isEActive = true;
        }
    }
   
}
