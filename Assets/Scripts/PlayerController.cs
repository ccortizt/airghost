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

    float propSpeed = 16;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        rb.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.rotation = Quaternion.Euler(0, 90, 0);
            rb.MovePosition(transform.position + Vector3.right / propSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.rotation = Quaternion.Euler(0, -90, 0);
            rb.MovePosition(transform.position - Vector3.right / propSpeed);
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.rotation = Quaternion.Euler(0, 0, 0);
            rb.MovePosition(transform.position + Vector3.forward / propSpeed);            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.rotation = Quaternion.Euler(0, 180, 0);
            rb.MovePosition(transform.position - Vector3.forward / propSpeed);            
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(sphereAtackPrefab, transform.position + transform.forward, transform.rotation);            
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

            //pos += transform.forward;

            Instantiate(sphereBombPrefab, pos, Quaternion.identity);
        }
    }

    public void SetPropSpeed(float value)
    {
        if (propSpeed == 16)
        {
            propSpeed = value;
            StartCoroutine(SetDefaultPropSpeed());
        }
    }

    public IEnumerator SetDefaultPropSpeed()
    {
        yield return new WaitForSeconds(3);
        propSpeed = 16;
    }

    public void Bump(Vector3 ghostPos){
        Vector3 aux = transform.position - ghostPos;
        aux.y = 0f;
        if ((transform.position + (aux * 2f)).x < 7.5f && (transform.position + (aux * 2f)).x > -7.5f && (transform.position + (aux * 2f)).z < 7.5f && (transform.position + (aux * 2f)).z > -7.5f)
            transform.position = transform.position + (aux * 2f);
    }
}
