using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LightsOnZone : MonoBehaviour {

	[SerializeField] TorchToggle[] lights;

	void OnTriggerEnter(){
		foreach (TorchToggle light in lights)
			light.SetOn(true);
		this.enabled = false;
	}
}
