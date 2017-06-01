using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBombController : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Explode());
    }


    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(3);

        Collider[] nearObjects = Physics.OverlapSphere(transform.position, 1f);

        foreach (Collider item in nearObjects)
        {

            if (item.gameObject.layer == 11)
            {
                //Debug.Log(item.gameObject.transform.position + " " + gameObject.transform.position);

                if (!IsDiagonal(item.gameObject.transform.position, transform.position))
                {
                    item.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    item.gameObject.GetComponent<MobileBoxController>().Move(transform.position - item.gameObject.transform.position);
                }
                else
                {
                    Debug.Log(Mathf.Abs((item.gameObject.transform.position - transform.position).x) + " " + Mathf.Abs((item.gameObject.transform.position - transform.position).z));
                }


            }

        }

        Destroy(gameObject, 0.01f);
    }


    private bool IsDiagonal(Vector3 box, Vector3 bomb)
    {
        return Mathf.Abs((bomb - box).x) > 0.01 && Mathf.Abs((bomb - box).z) > 0.01f;
    }

}
