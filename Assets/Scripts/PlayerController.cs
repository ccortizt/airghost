using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;

    private float propSpeed = 16;

    private AirShooter shooter;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        shooter = GetComponentInChildren<AirShooter>();
        GetComponent<Health>().OnDie += MakePlayerDie;
    }

    private void MakePlayerDie()
    {
        propSpeed = 0;
        //animation...
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
            shooter.ShootAirProjectile();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            shooter.ShootAirBomb();
        }
    }

    //public void SetPropSpeed(float value)
    //{
    //    if (propSpeed == 16)
    //    {
    //        propSpeed = value;
    //        StartCoroutine(SetDefaultPropSpeed());
    //    }
    //}

    //public IEnumerator SetDefaultPropSpeed()
    //{
    //    yield return new WaitForSeconds(3);
    //    propSpeed = 16;
    //}

    public void Bump(Vector3 ghostPos){
        
        //when 2 ghosts hits the player it can go out? check!
        Vector3 aux = transform.position - ghostPos;
        aux.y = 0f;
        if (transform.position.x < 12 && transform.position.x > 3 && transform.position.z < 12 && transform.position.z > 3)
        {
            //Debug.Log("bumped! " + aux);
            rb.MovePosition(transform.position + (aux * .75f));
        }
    }
}
