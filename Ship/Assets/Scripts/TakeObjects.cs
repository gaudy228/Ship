using System.Collections;

using UnityEngine;

public class TakeObjects : MonoBehaviour
{
    private bool canTakeObject;
    private bool isRealoding = true;
    private bool isQActive = true;
    [HideInInspector] public bool takingAndDrag = false;
    [SerializeField] private GameObject isObject;
    [SerializeField] private Transform sppCoal;

    [HideInInspector] public bool takeBattery = false;
    [SerializeField] private GameObject battery;
    private Battary batteryScript;
    public bool playerNeerSolar;
    public bool playerNeerGiveAway;
    void Start()
    {
        batteryScript = battery.GetComponent<Battary>();
    }

    
    void Update()
    {
        if(isObject != null)
        {
            TakeObject();

        }
      
        
    }
    private void TakeObject()
    {
        if(Input.GetKey(KeyCode.Q) && isRealoding && !isQActive)
        {
            takingAndDrag = false;
            isObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            isObject.GetComponent<BoxCollider2D>().isTrigger = false;
            isObject.transform.parent = null;
            isObject = null;
            
            isQActive = true;
            StartCoroutine(RealodTake());
        }
        else if (canTakeObject && Input.GetKey(KeyCode.Q) && isRealoding && isQActive)
        {
            takingAndDrag = true;
           
            isQActive = false;
            isObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            isObject.GetComponent<BoxCollider2D>().isTrigger = true;
            StartCoroutine(RealodTake());
        }

        if (takingAndDrag)
        {
            isObject.transform.position = sppCoal.position;    
            isObject.transform.parent = sppCoal.transform;
           
        }
        Battary();
    }
    private void Battary()
    {
        if (isObject == battery && takingAndDrag)
        {
            takeBattery = true;
        }
        else
        {
            takeBattery = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isObject == null && (collision.gameObject.CompareTag("Coal") || collision.gameObject.CompareTag("Battery")) && !takingAndDrag)
        {
            isObject = collision.gameObject;
            
            canTakeObject = true;
        }
        if (collision.gameObject.CompareTag("SolarPanel"))
        {
            playerNeerSolar = true;
        }
        if (collision.gameObject.CompareTag("GiveAway"))
        {
            playerNeerGiveAway = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Coal") || collision.gameObject.CompareTag("Battery")) && !takingAndDrag)
        {
            takingAndDrag = false;
            canTakeObject = false;
            isObject = null;
        }
        if (collision.gameObject.CompareTag("SolarPanel"))
        {
            playerNeerSolar = false;
        }
        if (collision.gameObject.CompareTag("GiveAway"))
        {
            playerNeerGiveAway = false;
        }
    }
    IEnumerator RealodTake()
    {
        isRealoding = false;
        yield return new WaitForSeconds(1);
        isRealoding = true;
    }
}
