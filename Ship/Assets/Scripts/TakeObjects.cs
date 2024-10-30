using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObjects : MonoBehaviour
{
    private bool canTakeObject;
    private bool isRealoding = true;
    private bool isQActive = true;
    private bool takingAndDrag = false;
    [SerializeField] private GameObject isObject;
    [SerializeField] private Transform sppCoal;
    private bool tpObject;
    void Start()
    {
        
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
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isObject == null & collision.gameObject.CompareTag("Coal") & !takingAndDrag)
        {
            isObject = collision.gameObject;
            canTakeObject = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coal") & !takingAndDrag & isObject == null)
        {
            takingAndDrag = false;
            canTakeObject = false;
            isObject = null;
        }
    }
    IEnumerator RealodTake()
    {
        isRealoding = false;
        yield return new WaitForSeconds(1);
        isRealoding = true;
    }
}
