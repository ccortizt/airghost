using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().OnDie += HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
