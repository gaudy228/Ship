using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private Topka topka;
    private GameObject player;
    [SerializeField] private LeverControlerTraun leverControlerTraun;

    private float stopSpeed;

    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if(topka.fullEnergy > 0 && !leverControlerTraun.stop)
        {
            transform.Translate(Vector3.right * topka.fullEnergy * Time.deltaTime * leverControlerTraun.currendSpeed);
            stopSpeed = topka.fullEnergy;
        }
        if (leverControlerTraun.stop)
        {
            if(stopSpeed > 0)
            {
                stopSpeed -= Time.deltaTime;
                transform.Translate(Vector3.right * topka.fullEnergy * Time.deltaTime / 3f);
            }
            else
            {
                stopSpeed = 0;
            }
            if (leverControlerTraun.goLeft && stopSpeed == 0)
            {
                transform.Translate(-Vector3.right * topka.fullEnergy * Time.deltaTime / 2f);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = null;
    }

}
