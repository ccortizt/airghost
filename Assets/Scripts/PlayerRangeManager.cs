using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeManager : MonoBehaviour
{

    private Light lt;
    private float timeCounter;
    private float ltIncrement;

    private SphereCollider activeRange;
    private float rangeIncrement;

    void Start()
    {
        lt = GetComponentInChildren<Light>();
        activeRange = GetComponent<SphereCollider>();
        timeCounter = 0f;
        ltIncrement = 0.015f;
        rangeIncrement = 0.0045f;
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
        if (coll.gameObject.name.Contains("Ghost"))
            StartCoroutine(coll.gameObject.GetComponent<GhostController>().EnableGhostNav(0f));
    }

    void OnTriggerExit(Collider coll)
    {

        if (coll.gameObject.name.Contains("Ghost"))
        {
            coll.gameObject.GetComponent<GhostController>().DisableGhostNav();
        }
    }


}
