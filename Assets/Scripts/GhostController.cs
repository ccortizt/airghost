using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GhostController : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        try
        {
            if (gameObject.GetComponent<NavMeshAgent>().enabled)
            {
                gameObject.GetComponent<NavMeshAgent>().destination = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(ex);
        }
    }
}
