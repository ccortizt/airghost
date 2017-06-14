using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPortal : MonoBehaviour
{

    const int RAGE = 1;
    const int FEAR = 2;
    const int SADNESS = 3;

    private int portalType = 0;


    private bool canSpawnGhost;

    [SerializeField]
    GameObject rageGhost;

    [SerializeField]
    GameObject fearGhost;

    [SerializeField]
    GameObject sadnessGhost;


    [SerializeField]
    Material rageMat;

    [SerializeField]
    Material fearMat;

    [SerializeField]
    Material sadnessMat;

    private float timeCounter;
    private float timePeak;

    private void Start()
    {
        canSpawnGhost = true;

        timePeak = Random.Range(20, 45);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().OnDie += StopSpawning;
    }

    private void StopSpawning()
    {
        canSpawnGhost = false;
    }

    private void Update()
    {
        timeCounter = timeCounter + Time.deltaTime;

        if (timeCounter > timePeak)
        {
            if (canSpawnGhost)
            {
                SpawnGhost();
                RestartCounter();
            }

        }
    }

    void RestartCounter()
    {
        timeCounter = 0;
    }

    public void SetType(int type)
    {
        portalType = type;
        if (portalType == RAGE)
            gameObject.GetComponent<Renderer>().material = rageMat;

        if (portalType == SADNESS)
            gameObject.GetComponent<Renderer>().material = sadnessMat;

        if (portalType == FEAR)
            gameObject.GetComponent<Renderer>().material = fearMat;
    }

    private void SpawnGhost()
    {
        
        if (portalType == RAGE)
        {
            Instantiate(rageGhost, transform.position + Vector3.up, Quaternion.identity);
        }

        else if (portalType == FEAR)
        {
            Instantiate(fearGhost, transform.position + Vector3.up, Quaternion.identity);
        }
        else if (portalType == SADNESS)
        {
            Instantiate(sadnessGhost, transform.position + Vector3.up, Quaternion.identity);
        }
       
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Box"))
        {
            canSpawnGhost = false;
        }
    }

}
