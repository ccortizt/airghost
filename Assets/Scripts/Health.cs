using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField]
    private float initialHealth;

    private float currentHealth;

    public float CurrentHealthPercentage
    {
        get { return (float)currentHealth / initialHealth; }
    }

    public event Action<float> OnDamageTaken = delegate { };

    public event Action OnDie = delegate { };


    private void Start()
    {
        currentHealth = initialHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (OnDamageTaken != null)
        {
            OnDamageTaken(CurrentHealthPercentage);
        }

        if (currentHealth <= 0)
        {
            Die();
        }


    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died");

        if (OnDie != null)
        {
            OnDie();
        }
    }
}
