using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSphere : MonoBehaviour
{

    private float sphereSpeed;
    private float sphereDelay;
    private float destroyDelay;

    void Start()
    {
        sphereSpeed = 3.5f;
        sphereDelay = .5f;
        destroyDelay = 3f;

        StartCoroutine(MoveSphere(sphereDelay));
        Destroy(gameObject, destroyDelay);
    }
    
    void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.name.Contains("Player") || !coll.gameObject.name.Contains("Air"))
            Destroy(gameObject);
    }

    private IEnumerator MoveSphere(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Rigidbody>().velocity = transform.forward * sphereSpeed;
    }
}
