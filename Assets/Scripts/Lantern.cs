using UnityEngine;
using System.Collections;

public class Lantern : MonoBehaviour {

	Light source;

	// Use this for initialization
	void Start () {
		source = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Toggle Lantern")) {
			if(source.enabled){
				TurnOff();
				//print ("Turning Off");
			} else {
				TurnOn();
				//print ("Turning On");
			}
		}
	}

	void TurnOff(){
		source.enabled = false;
	}

	void TurnOn(){
		source.enabled = true;
	}
}
