using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour
{
    public bool isFly = false;
    
    [SerializeField] private float speedFly;
    [SerializeField] private Transform topkaCheck;
    [SerializeField] private float overlapRadius;
    [SerializeField] private LayerMask topkaL;
    private bool oneMake = true;
    private GameObject player;
    private TakeObjects takeObjects;
    private GameObject topkaG;
    private Topka topka;

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        takeObjects = player.GetComponent<TakeObjects>();
        topkaG = GameObject.FindWithTag("Topka");
        topka = topkaG.GetComponent<Topka>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckTopka();
        if (isFly)
        {
            
            if(oneMake)
            {
                GetComponent<BoxCollider2D>().isTrigger = true;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                oneMake = false;
            }
            transform.Translate(Vector3.up * speedFly * Time.deltaTime);
            
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StarterCoal"))
        {
            topka.countFuel++;
            topka.fuel += topka.plusFuel;
            topka.energy += topka.plusEnergy;
            Destroy(gameObject);
        }
    }
    private void CheckTopka()
    {
        if(Physics2D.OverlapCircle(topkaCheck.position, overlapRadius, topkaL) && !takeObjects.takingAndDrag)
        {
            isFly = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(topkaCheck.position, overlapRadius);
    }
}
