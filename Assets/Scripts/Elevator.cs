using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	[SerializeField] List<Transform> floorStops;
	[SerializeField] float moveSpeed = 2f;

	int targetFloor = 0;

	// Use this for initialization
	void Start () {
		transform.position = floorStops[0].position;
	}
	
	// Update is called once per frame
	void Update () {
		MoveToFloor(targetFloor);
	}

	void MoveToFloor(int floor){
		transform.position = Vector3.MoveTowards(transform.position, floorStops[floor].position, moveSpeed * Time.deltaTime);
	}

	public void goToNextFloor(){
		targetFloor = Mathf.Min(++targetFloor, floorStops.Count);
	}

	public void goToPrevFloor(){
		targetFloor = Mathf.Max(--targetFloor, 0);
	}
}
