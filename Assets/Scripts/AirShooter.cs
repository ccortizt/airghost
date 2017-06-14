using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject sphereAtackPrefab;

    [SerializeField]
    private GameObject sphereBombPrefab;

    private Transform parentTransform; 

    private void Start()
    {
        parentTransform = GetComponentInParent<Transform>();
    }

    public void ShootAirProjectile()
    {
        Instantiate(sphereAtackPrefab, parentTransform.position, parentTransform.rotation);
    }

    public void ShootAirBomb(){
        Vector3 pos;

        pos.y = 0.5f;

        if ((parentTransform.position.x - Mathf.Round(parentTransform.position.x)) < 0)
        {
            pos.x = Mathf.Ceil(parentTransform.position.x) - 0.5f;
        }

        else
        {
            pos.x = Mathf.Floor(parentTransform.position.x) + 0.5f;
        }

        if ((parentTransform.position.z - Mathf.Round(parentTransform.position.z)) < 0)
        {
            pos.z = Mathf.Ceil(parentTransform.position.z) - 0.5f;
        }
        else
        {
            pos.z = Mathf.Floor(parentTransform.position.z) + 0.5f;
        }
        
        Instantiate(sphereBombPrefab, pos, Quaternion.identity);
    }
}
