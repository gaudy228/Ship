using TMPro;
using UnityEngine;

public class Topka : MonoBehaviour
{
    
    public float fuel;
    public float energy;
   
    public float puffCount;

    public float fullEnergy;
    [Header("Parametrs")]
    public float countFuel;
    public float plusFuel;
    public float plusEnergy;
    public float divideMinusFuel;
    [SerializeField] private float maxEnergy;
    [SerializeField] private float maxFuel;
    private LeverTrain leverTrain;

    [SerializeField] private TextMeshProUGUI textFuel;
    [SerializeField] private TextMeshProUGUI textEnergy;
    [SerializeField] private TextMeshProUGUI textPuff;
    void Start()
    {
        leverTrain = GetComponent<LeverTrain>();
    }

    
    void Update()
    {
        textFuel.text = "Топливо: " + fuel.ToString("0.0") + " / 250";
        textEnergy.text = "Енергия: " + energy.ToString("0.0") + " / 400";
        textPuff.text = "Топка: " + puffCount.ToString() + " / 8";
        fullEnergy = energy * puffCount  / (100 * leverTrain.divideSpeedTrain);
        
        if (countFuel > 5)
        {
            countFuel = 5;
        }
        if(energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }
        if (countFuel > 0)
        {
            
            if(fuel > 0)
            {
                fuel -= Time.deltaTime * puffCount / divideMinusFuel;
            }
            else
            {
                fuel = 0;
            }
            if(energy > 0)
            {
                if(fuel > 0)
                {
                    energy -= Time.deltaTime * 2;
                }
                else if(fuel <= 0)
                {
                    energy -= Time.deltaTime * 5;
                }
                
            }
            else
            {
                energy = 0;
            }
        }
       
        
        
    }
}
