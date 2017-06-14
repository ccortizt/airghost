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
    private bool canPursuit;

    private Rigidbody rb;
    private GameObject player;

    private NavMeshAgent nav;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();

        canMove = true;
        canPursuit = true;
        RestartCounter();
        timePeak = Random.Range(3, 5);
        DisableGhostNav();

        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().OnDie += HandlePlayerDeath;
        gameObject.GetComponent<Health>().OnDie += HandleOwnDeath;
    }

    private void HandlePlayerDeath()
    {
        StopMovement();
        
        canMove = false;
        canPursuit = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        
    }

    private void HandleOwnDeath()
    {
        Destroy(gameObject);
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
            if (nav.enabled && canPursuit)
            {
                nav.destination = player.gameObject.transform.position;
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
        
        if (nav.enabled == false && canMove)
        {
            Vector3 rand = Random.insideUnitSphere / 2;
            rand.y = 0;
            rb.velocity = rand * moveSpeed;
        }
    }

    private void StopMovement()
    {
        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("AirSphere"))
        {
            Destroy(coll.gameObject);
            canMove = false;
            GetComponent<Health>().TakeDamage(1);
            DisableGhostNav();
            StopMovement();
            StartCoroutine(EnableGhostMove(5));            

        }

        if (coll.gameObject.name.Contains("Wall"))
        {
            StopMovement();
        }

        if (coll.gameObject.CompareTag("Player") && canPursuit)
        {
            coll.gameObject.GetComponent<Health>().TakeDamage(5);

            nav.enabled = false;
            StartCoroutine(EnableGhostNav(1));

            //if(gameObject.name.Contains("Fear"))
            //    coll.gameObject.GetComponent<PlayerController>().SetPropSpeed(32);
            //if (gameObject.name.Contains("Sadness"))
            //    coll.gameObject.GetComponent<PlayerController>().SetPropSpeed(32);
            //if (gameObject.name.Contains("Rage"))
            //    coll.gameObject.GetComponent<PlayerController>().SetPropSpeed(4);

            coll.gameObject.GetComponent<PlayerController>().Bump(gameObject.transform.position);

        }
    }

  
    public IEnumerator EnableGhostNav(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        nav.enabled = true;
  
    }

    public void DisableGhostNav()
    {
        nav.enabled = false;
    }

    private IEnumerator EnableGhostMove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canMove = true;
    }
}
