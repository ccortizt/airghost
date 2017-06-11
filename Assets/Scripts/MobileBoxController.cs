using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileBoxController : MonoBehaviour
{
        
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Move(Vector3 direction)
    {
        //Debug.Log(direction);
        GetComponent<Rigidbody>().velocity = -direction * 25;
        StartCoroutine(SetKinematic());
    }

    private IEnumerator SetKinematic()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
