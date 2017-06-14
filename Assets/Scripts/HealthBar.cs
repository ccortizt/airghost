using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour
{

    private Image healthBar;
    [SerializeField]
    private GameObject character;

    void Start()
    {
        healthBar = gameObject.GetComponent<Image>();
        character.GetComponent<Health>().OnDamageTaken += HandleAirBarChanged;

    }


    private void HandleAirBarChanged(float pct)
    {
        healthBar.fillAmount = pct;
    }
}
