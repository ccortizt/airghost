using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostUIController : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
    }
    public void EnableCanvas(){
        gameObject.GetComponentInChildren<Canvas>().enabled = true;
    }

    public void DisableCanvas()
    {
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
    }
}
