using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBarController : MonoBehaviour
{


    private float airLevel;
    private float initialAirLevel = 100;

    private Image airBar;


    void Start()
    {

        airBar = GameObject.FindGameObjectWithTag("AirBar").GetComponent<Image>();
        airLevel = initialAirLevel;
        UpdateAirBar();
    }

    void Update()
    {
        if (airLevel < 0)
        {
            Debug.Log("Lose");
        }
    }

    public void AddAir(float quantity)
    {
        if (airLevel < initialAirLevel)
        {
            if (airLevel + quantity > initialAirLevel)
                airLevel = initialAirLevel;
            else
                airLevel += quantity;

            UpdateAirBar();
        }
    }

    public void DecreaseAir(float quantity)
    {
        if (airLevel > 0)
        {
            airLevel -= quantity;

            UpdateAirBar();
        }
    }

    private void UpdateAirBar()
    {
        airBar.fillAmount = (float)airLevel / (float)initialAirLevel;
        //Debug.Log("energy: " + airLevel);

    }

    public float GetAirLevel()
    {
        return airLevel;
    }
}
