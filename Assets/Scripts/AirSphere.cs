using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSphere : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(MoveSphere(2f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.name.Contains("Player") || !coll.gameObject.name.Contains("Air"))
            Destroy(gameObject);
    }

    private IEnumerator MoveSphere(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Rigidbody>().velocity = transform.forward * 6f;
    }
}
