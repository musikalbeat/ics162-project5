using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : MonoBehaviour {

	[SerializeField] Elevator elevator;

	bool playerInRegion = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && playerInRegion){
			elevator.goToNextFloor();
		}
		if (Input.GetKeyDown(KeyCode.R) && playerInRegion){
			elevator.goToPrevFloor();
		}
	}

	void OnTriggerEnter(){
		print("entered");
		playerInRegion = true;
	}

	void OnTriggerExit(){
		print("exited");
		playerInRegion = false;
	}
}
