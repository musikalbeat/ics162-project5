using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLights : MonoBehaviour {

	[SerializeField] float speed = 6f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.up);
	}
}
