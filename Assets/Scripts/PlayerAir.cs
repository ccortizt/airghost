using System;
using UnityEngine;

public class PlayerAir : MonoBehaviour
{

    private float airLevel;
    private float initialAirLevel = 100;
      

    private float CurrentAirPercentage { get { return (float)airLevel / (float)initialAirLevel; } }

    public event Action<float> OnAirPercentageChanged = delegate { };

    void Start()
    {       
        airLevel = initialAirLevel;        
    }

    void Update()
    {
        
    }

    public void DecreaseAir(float quantity)
    {
        if (airLevel - quantity > 0)
        {
            airLevel -= quantity;
            if (OnAirPercentageChanged != null)
                OnAirPercentageChanged(CurrentAirPercentage);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name+" died");
    }
}
