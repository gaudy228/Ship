using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private Topka topka;
    private GameObject player;
    [SerializeField] private LeverControlerTraun leverControlerTraun;

    private float rememberSpeed;

    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        GoRightFullSpeed();
        GoRightHalfSpeed();
        Stop();
        GoLeft();
    }
    private void Stop()
    {
        if (leverControlerTraun.stop)
        {
            if (rememberSpeed > 0)
            {
                rememberSpeed -= Time.deltaTime;
                transform.Translate(Vector3.right * topka.fullEnergy * Time.deltaTime / 3f);
            }
            else
            {
                rememberSpeed = 0;
            }
            
        }
    }
    private void GoRightFullSpeed()
    {
        if (topka.fullEnergy > 0 && !leverControlerTraun.stop && leverControlerTraun.goRight)
        {
            if(leverControlerTraun.currendSpeed < 1)
            {
                leverControlerTraun.currendSpeed += Time.deltaTime / 10f;
            }
            else
            {
                leverControlerTraun.currendSpeed = 1;
            }
            transform.Translate(Vector3.right * topka.fullEnergy * Time.deltaTime * leverControlerTraun.currendSpeed);
            rememberSpeed = topka.fullEnergy;
        }
    }
    private void GoRightHalfSpeed()
    {
        if (topka.fullEnergy > 0 && !leverControlerTraun.stop && leverControlerTraun.goHalfRight)
        {

            if (leverControlerTraun.currendSpeed > 0.51f)
            {
                leverControlerTraun.currendSpeed -= Time.deltaTime / 10f;
            }
            else if (leverControlerTraun.currendSpeed < 0.49f)
            {
                leverControlerTraun.currendSpeed += Time.deltaTime / 10f;
            }
            else
            {
                leverControlerTraun.currendSpeed = 0.5f;
            }
            transform.Translate(Vector3.right * topka.fullEnergy * Time.deltaTime * leverControlerTraun.currendSpeed);
            rememberSpeed = topka.fullEnergy;
        }
    }
    private void GoLeft()
    {
        if (leverControlerTraun.goLeft && rememberSpeed == 0)
        {
            transform.Translate(-Vector3.right * topka.fullEnergy * Time.deltaTime / 2f);
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
