using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject player;
	private Vector3 distance;

	void Start () {		
		distance = transform.position - GameObject.Find ("Player").transform.position;
	}
		
	void LateUpdate () {	
		transform.position = GameObject.Find ("Player").transform.position + distance;		
	}

}
