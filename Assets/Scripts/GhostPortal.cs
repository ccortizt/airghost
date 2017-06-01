using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPortal : MonoBehaviour
{

    const int ANGRY = 1;
    const int FEAR = 2;
    const int SADNESS = 3;

    private int portalType = 0;

    
    private bool canSpawnGhost;

    [SerializeField]
    GameObject angryGhost;

    [SerializeField]
    GameObject fearGhost;

    [SerializeField]
    GameObject sadnessGhost;


    [SerializeField]
    Material angryMat;

    [SerializeField]
    Material fearMat;

    [SerializeField]
    Material sadnessMat;

    private void Start()
    {
        canSpawnGhost = true;
        SetType(1);
        StartCoroutine(SpawnGhost(20));
    }

    private void Update()
    {

    }

    public void SetType(int type)
    {
        portalType = type;
        if (portalType == ANGRY)
            gameObject.GetComponent<Renderer>().material = angryMat;

        if (portalType == SADNESS)
            gameObject.GetComponent<Renderer>().material = sadnessMat;

        if (portalType == FEAR)
            gameObject.GetComponent<Renderer>().material = fearMat;
    }

    private IEnumerator SpawnGhost(float waitTime)
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(canSpawnGhost+" new ghost");
            if (canSpawnGhost)
            {
                if (portalType == ANGRY)
                {
                    Instantiate(angryGhost, transform.position, Quaternion.identity);
                }

                else if (portalType == FEAR)
                {
                    Instantiate(fearGhost, transform.position, Quaternion.identity);
                }
                else if (portalType == SADNESS)
                {
                    Instantiate(sadnessGhost, transform.position, Quaternion.identity);
                }
                else
                {

                }
            }
            yield return new WaitForSeconds(waitTime);

        }
    }

    //public void SetCanSpawnGhost(bool canSpawnNow)
    //{
    //    canSpawnGhost = canSpawnNow;
    //}

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("Box"))
        {
            canSpawnGhost = false;
        }
    }

}
