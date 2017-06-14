using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{

    private float currentHealth;

    public float CurrentHealthPercentage
    {
        get { return (float) currentHealth / initialHealth; }        
    }

    public event Action<float> OnDamageTaken = delegate { };

    [SerializeField]
    private float initialHealth;

    private void Start()
    {
        currentHealth = initialHealth;
    }

    public void TakeDamage(float damage)
    {
       
        if (currentHealth - damage > 0)
        {

            currentHealth -= damage;
            if(OnDamageTaken != null)
                OnDamageTaken(CurrentHealthPercentage);
        }
        else
        {
            Die();
        }

    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }
}
