using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileBoxController : MonoBehaviour
{
    private Rigidbody rb;
    
        
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {

    }

    public void Move(Vector3 direction)
    {
        Debug.Log(direction);
        rb.velocity = -direction * 25;
        StartCoroutine(SetKinematic());
    }

    private IEnumerator SetKinematic()
    {
        yield return new WaitForSeconds(3);
        rb.isKinematic = true;
    }
}
