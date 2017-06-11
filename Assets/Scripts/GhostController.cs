using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GhostController : MonoBehaviour
{

    private float moveSpeed = .8f;

    private float timeCounter;
    private float timePeak;

    private bool canMove;
    void Start()
    {
        canMove = true;
        RestartCounter();
        timePeak = Random.Range(3, 5);
        DisableGhostNav();
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
            DisableGhostNav();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            StartCoroutine(EnableGhostMove(5));

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

  
    public IEnumerator EnableGhostNav(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
  
    }

    public void DisableGhostNav()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    private IEnumerator EnableGhostMove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
    }
}
