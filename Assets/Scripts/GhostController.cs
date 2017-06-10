﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GhostController : MonoBehaviour
{

    private float moveSpeed = 3;

    private float timeCounter;
    private float timePeak;

    private bool canMove;
    void Start()
    {
        canMove = true;
        RestartCounter();
        timePeak = Random.Range(3, 5);
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    void Update()
    {
        timeCounter = timeCounter + Time.deltaTime;

        if (timeCounter > timePeak)
        {
            RandomMovement();
            RestartCounter();
            timePeak = Random.Range(3, 5);
        }

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

    void RestartCounter()
    {
        timeCounter = 0;
    }

    private void RandomMovement()
    {
        //Debug.Log("random");
        if (gameObject.GetComponent<NavMeshAgent>().enabled == false && canMove)
        {
            Vector3 rand = Random.insideUnitSphere / 2;
            rand.y = 0;
            GetComponent<Rigidbody>().velocity = rand * moveSpeed;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("AirSphere"))
        {
            Destroy(coll.gameObject);
            canMove = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            StartCoroutine(EnableGhostMove(5));
            Debug.Log("in");

        }

        if (coll.gameObject.name.Contains("Wall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (coll.gameObject.name.Contains("Player"))
        {
            coll.gameObject.GetComponent<AirBarController>().DecreaseAir(5);

            if(gameObject.name.Contains("Fear"))
                coll.gameObject.GetComponent<PlayerController>().SetPropSpeed(32);
            if (gameObject.name.Contains("Sadness"))
                coll.gameObject.GetComponent<PlayerController>().SetPropSpeed(32);
            if (gameObject.name.Contains("Rage"))
                coll.gameObject.GetComponent<PlayerController>().SetPropSpeed(4);

            coll.gameObject.GetComponent<PlayerController>().Bump(gameObject.transform.position);

        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.name.Contains("Player"))
            StartCoroutine(EnableGhostNav(0.5f));
    }

    void OnTriggerExit(Collider coll)
    {

        if (coll.gameObject.name.Contains("Player"))
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            //Debug.Log("not enabled");
        }
    }

    private IEnumerator EnableGhostNav(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        //Debug.Log("enabled");
    }

    private IEnumerator EnableGhostMove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
    }
}
