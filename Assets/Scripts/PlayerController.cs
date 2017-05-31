using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    GameObject sphereAtackPrefab;

    [SerializeField]
    GameObject sphereBombPrefab;

    private Rigidbody rb;

    float propSpeed = 8;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        rb.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.rotation = Quaternion.Euler(0, 0, 0);
            rb.MovePosition(transform.position + Vector3.forward / propSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.rotation = Quaternion.Euler(0, 180, 0);
            rb.MovePosition(transform.position - Vector3.forward / propSpeed);
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.rotation = Quaternion.Euler(0, -90, 0);
            rb.MovePosition(transform.position - Vector3.right / propSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.rotation = Quaternion.Euler(0, 90, 0);
            rb.MovePosition(transform.position + Vector3.right / propSpeed);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            var airball = (GameObject)Instantiate(sphereAtackPrefab, transform.position + transform.forward, Quaternion.identity);
            airball.GetComponent<Rigidbody>().velocity = transform.forward * 2;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Vector3 pos;

            pos.y = 0.5f;

            if ((transform.position.x - Mathf.Round(transform.position.x)) < 0)
            {
                pos.x = Mathf.Ceil(transform.position.x) - 0.5f;
            }
            else
            {
                pos.x = Mathf.Floor(transform.position.x) + 0.5f;
            }

            if ((transform.position.z - Mathf.Round(transform.position.z)) < 0)
            {
                pos.z = Mathf.Ceil(transform.position.z) - 0.5f;
            }
            else
            {
                pos.z = Mathf.Floor(transform.position.z) + 0.5f;
            }

            Instantiate(sphereBombPrefab, pos, Quaternion.identity);
        }
    }

}
