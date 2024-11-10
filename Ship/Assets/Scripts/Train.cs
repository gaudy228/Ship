using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private Topka topka;
    private GameObject player;


    private LeverTrain leverTrain;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        leverTrain = player.GetComponent<LeverTrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if(topka.fullEnergy > 0)
        {
            transform.Translate(Vector3.right * topka.fullEnergy * Time.deltaTime * leverTrain.LRorLL);
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