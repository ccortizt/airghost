using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSphere : MonoBehaviour
{

    private float sphereSpeed;
    private float sphereDelay;
    void Start()
    {
        sphereSpeed = 1f;
        sphereDelay = .5f;
        StartCoroutine(MoveSphere(sphereDelay));
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
