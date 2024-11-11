using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float climbSpeed;
    [HideInInspector] public Rigidbody2D rb;
    private bool canJump = true;
    
    private bool canClimb = false;
    private bool isEActive = true;
    private bool isLadder = false;
    private bool isRealoding = true;

    [SerializeField] private Puff puffScript;

    [SerializeField] private LayerMask puff;
    [HideInInspector] public bool canPuff = false;
    [Header("OverlapFloor")]
    [SerializeField] private Transform checkFloor;
    [SerializeField] private float overlapRadius;
    [SerializeField] private LayerMask floor;
    [SerializeField] private GameObject win;

    [Header("OverlapFloor")]
    [SerializeField] private float speedWhenMoveLever;
    public bool canMoveLever = false;
    private Rigidbody2D rbLever;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (!canMoveLever)
        {
            Move();
        }
            Jump();
            LeverControlTrain();
            if (canClimb)
            {
                ClimbLadder();

            }
        
        
        canJump = Physics2D.OverlapCircle(checkFloor.position, overlapRadius, floor);
        canPuff = Physics2D.OverlapCircle(checkFloor.position, overlapRadius, puff);
    }
    void Update()
    {
        
    }
    private void Move()
    {
        
       rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        
        
            
        
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1.1f, 1.1f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1.1f, 1.1f, 0);
        }

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
        if(Input.GetKey(KeyCode.E) && !isEActive && isRealoding)
        {
            isLadder = false;
            isEActive = true;
            rb.gravityScale = 1;
            StartCoroutine(RealodClimb());
        }
        else if (Input.GetKey(KeyCode.E) && isEActive && isRealoding)
        {
            isLadder = true;
            isEActive = false;
            rb.gravityScale = 0;
            StartCoroutine(RealodClimb());
        }
        
        if (isLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * climbSpeed);
            rb.gravityScale = 0;  
        }
        
      
    }
    private void LeverControlTrain()
    {
        if(rbLever != null && Input.GetKey(KeyCode.LeftShift) && canMoveLever)
        {
            rbLever.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speedWhenMoveLever, 0);
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speedWhenMoveLever, rb.velocity.y);
        }
        else
        {
            if(rbLever != null)
            {
                rbLever.velocity = Vector2.zero;
            }
            Move();
        }
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = true;
            
        }
        if (collision.gameObject.CompareTag("Topka"))
        {
            BackMenu();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("LeverControl"))
        {
            canMoveLever = true;
            rbLever = collision.gameObject.GetComponent<Rigidbody2D>();
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
            rb.gravityScale = 1;
            isEActive = true;
            isLadder = false;
        }
        if (collision.gameObject.CompareTag("Die"))
        {
            BackMenu();
        }
        if (collision.gameObject.CompareTag("LeverControl"))
        {
            canMoveLever = false;
            if(rbLever != null)
            {
                rbLever.velocity = Vector2.zero;
            }
            
            rbLever = null;
            
        }
    }
    IEnumerator RealodClimb()
    {
        isRealoding = false;
        yield return new WaitForSeconds(1);
        isRealoding = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(checkFloor.position, overlapRadius);
    }

}
