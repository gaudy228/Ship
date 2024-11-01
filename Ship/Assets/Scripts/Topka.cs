using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topka : MonoBehaviour
{
    public float countFuel;
    public float fuel;
    public float energy;
    public float plusFuel;
    public float plusEnergy;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(countFuel > 5)
        {
            countFuel = 5;
        }
        if(countFuel > 0)
        {
            fuel -= Time.deltaTime / 3.5f;
            if(fuel <= 0)
            {
                countFuel = 0;
            }
            energy -= Time.deltaTime;
        }
        else
        {
            fuel = 0;
            energy = 0;
        }
        
        
    }
}
