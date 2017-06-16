using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardCanvas : MonoBehaviour {


	void FixedUpdate () {
        if (Camera.main != null)
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                Camera.main.transform.rotation * Vector3.up);
        //else
        //    transform.LookAt(transform.position + Camera.current.transform.rotation * Vector3.forward,
        //        Camera.current.transform.rotation * Vector3.up);
	}
}
