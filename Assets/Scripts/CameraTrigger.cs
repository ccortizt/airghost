using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private Camera topCamera;

    [SerializeField]
    private Camera mainCamera;

    void Start()
    {
        topCamera.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.enabled = false;            
            topCamera.enabled = true;
            topCamera.transform.position = new Vector3(gameObject.transform.position.x, topCamera.transform.position.y, gameObject.transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            mainCamera.enabled = true;
            topCamera.enabled = false;
        }
    }
}
