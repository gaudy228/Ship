using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrain : MonoBehaviour
{
    private bool LR = false;
    private bool LL = false;
    private bool LS = false;
    [HideInInspector] public float LRorLL = 1;
    [HideInInspector] public float divideSpeedTrain = 1;
    private Topka topka;
    void Start()
    {
        topka = GetComponent<Topka>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LR && Input.GetKey(KeyCode.E))
        {
            LRorLL = 1;
            divideSpeedTrain = 1;
        }
        if (LL && Input.GetKey(KeyCode.E))
        {
            LRorLL = -1;
            divideSpeedTrain = 3;
        }
        if (LS && Input.GetKey(KeyCode.E))
        {
            topka.fuel = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LR"))
        {
            LR = true;
        }
        if (collision.gameObject.CompareTag("LL"))
        {
            LL = true;
        }
        if (collision.gameObject.CompareTag("LS"))
        {
            LS = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LR"))
        {
            LR = false;
        }
        if (collision.gameObject.CompareTag("LL"))
        {
            LL = false;
        }
        if (collision.gameObject.CompareTag("LS"))
        {
            LS = false;
        }

    }
}
