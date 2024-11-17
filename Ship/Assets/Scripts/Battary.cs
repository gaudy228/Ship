using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battary : MonoBehaviour
{
    [SerializeField] private float currentEnergy;
    [SerializeField] private float maxEnergy;
    [SerializeField] private float plusEnergy;
    [SerializeField] private float minusEnergy;
    private GameObject solarPanel;
    private GameObject giveAwayEnergy;
    private bool neerSolar;
    private bool neerGiveAway;
    private TakeObjects takeObjects;
    private GameObject gPlayer;
    private bool isCharging = false;
    private bool isGiveAway;
    private Rigidbody2D rb;
    void Start()
    {
        gPlayer = GameObject.FindWithTag("Player");
        takeObjects = gPlayer.GetComponent<TakeObjects>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BattaryCharging();
        BattaryGiveAway();
    }
    private void BattaryCharging()
    {
        if (Input.GetKeyDown(KeyCode.F) && neerSolar && takeObjects.takeBattery)
        {
            takeObjects.takingAndDrag = false;
            transform.parent = null;
            isCharging = true;
            
        }
        if (Input.GetKeyDown(KeyCode.F) && neerSolar && !takeObjects.takeBattery && takeObjects.playerNeerSolar)
        {
            isCharging = false;
            rb.gravityScale = 1.0f;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if (isCharging)
        {
            transform.position = solarPanel.transform.position;
            if (currentEnergy < maxEnergy)
            {
                currentEnergy += Time.deltaTime * plusEnergy;
            }
            else
            {
                currentEnergy = maxEnergy;
            }
        }
    }
    private void BattaryGiveAway()
    {
        if (Input.GetKeyDown(KeyCode.F) && neerGiveAway && takeObjects.takeBattery)
        {
            takeObjects.takingAndDrag = false;
            transform.parent = null;
            isGiveAway = true;

        }
        if (Input.GetKeyDown(KeyCode.F) && neerGiveAway && !takeObjects.takeBattery && takeObjects.playerNeerGiveAway)
        {
            isGiveAway = false;
            rb.gravityScale = 1.0f;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if (isGiveAway)
        {
            transform.position = giveAwayEnergy.transform.position;
            if (currentEnergy > 0)
            {
                currentEnergy -= Time.deltaTime * minusEnergy;
            }
            else
            {
                currentEnergy = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SolarPanel"))
        {
            neerSolar = true;
            solarPanel = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("GiveAway"))
        {
            neerGiveAway = true;
            giveAwayEnergy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SolarPanel"))
        {
            neerSolar = false;
            solarPanel = null;
        }
        if (collision.gameObject.CompareTag("GiveAway"))
        {
            neerGiveAway = false;
            giveAwayEnergy = null;
        }
    }
}
