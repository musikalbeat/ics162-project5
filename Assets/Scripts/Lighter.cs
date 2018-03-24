using UnityEngine;
using System.Collections;

public class Lighter : MonoBehaviour {
	[SerializeField] float range = 15f;
	[SerializeField] float tolerance = 3f;
	[SerializeField] float cooldown = 2f;

	float cooldownTimer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(cooldownTimer > 0f){
			cooldownTimer -= Time.deltaTime;
		}

		if (cooldownTimer <= 0 && Input.GetButtonDown ("Fire2")) {
			if(LighterAction()){
				cooldownTimer = cooldown;
			}
		}
	}

	bool LighterAction(){
		RaycastHit hit;
		//print ("Lighter casting");
		if(RayCastForward(out hit)){
			/*
			if(InSpectreRange(hit.point)){
				//print ("Lighter found Spectre in range");
				return false;
			}
			*/
			//print ("Lighter hit");
			return EnableAll(FindTargets(hit.point));
		}
		//print ("Lighter missed");
		return false;
	}

	bool RayCastForward(out RaycastHit hit){
		hit = new RaycastHit();
		return Physics.Raycast (transform.position, transform.forward, out hit, range);
	}

	Collider[] FindTargets(Vector3 point){
		return Physics.OverlapSphere(point, tolerance);
	}

	bool EnableAll(Collider[] targets){
		bool foundTorch = false;
		foreach(Collider col in targets){
			if(TurnOn (col.gameObject.GetComponent<TorchToggle>())){
				foundTorch = true;
			}
		}
		return foundTorch;
	}

	bool TurnOn(TorchToggle toggler){
		if(toggler != null){
			return toggler.TurnOn();
		}
		return false;
	}
}
