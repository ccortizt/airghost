﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeManager : MonoBehaviour
{

    private Light lt;
    private float timeCounter;
    private float ltIncrement;

    private SphereCollider activeRange;
    private float rangeIncrement;

    private bool isRangeActive;

    void Start()
    {
        isRangeActive = true;
        lt = GetComponentInChildren<Light>();
        activeRange = GetComponent<SphereCollider>();
        timeCounter = 0f;
        ltIncrement = 0.015f;
        rangeIncrement = 0.0045f;
        GetComponent<Health>().OnDie += HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        isRangeActive = false;
        ltIncrement = 0;
        rangeIncrement = 0;

    }
    
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (Mathf.Round(timeCounter) % 2 == 0)
        {            
            lt.spotAngle += ltIncrement; 
            activeRange.radius += rangeIncrement;
        }
    }


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.layer == 13 && isRangeActive)
        {
            StartCoroutine(coll.gameObject.GetComponent<GhostController>().EnableGhostNav(0f));
            coll.gameObject.GetComponent<GhostUIController>().EnableCanvas();
        }
    }

    void OnTriggerExit(Collider coll)
    {

        if (coll.gameObject.layer == 13)
        {
            coll.gameObject.GetComponent<GhostController>().DisableGhostNav();
            coll.gameObject.GetComponent<GhostUIController>().DisableCanvas();
        }
    }


}
