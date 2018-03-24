using UnityEngine;
using System.Collections;

public class TorchToggle : MonoBehaviour {

	[SerializeField] bool onAtStart = false;
	bool hasLightParticles;
	[SerializeField] GameObject lightParticles;
	[SerializeField] Light lightSource;


	GameObject lockout;
	bool isOn;

	public bool GetIsOn(){
		return isOn;
	}

	void Awake () {
		hasLightParticles = (lightParticles != null);
		isOn = onAtStart;
		SetOn (onAtStart);
//		if (onAtStart) {
//			TurnOn ();
//		} else {
//			TurnOff();
//		}
	}

	public bool SetOn(bool setOn, GameObject toggler = null, bool overrideMode = false){
		if(!overrideMode && lockout != null && toggler != lockout){
			return false;
		}
		if(hasLightParticles){
			lightParticles.SetActive (setOn);
		}
		lightSource.enabled = setOn;
		if(isOn != setOn){
			isOn = setOn;
			return true;
		}
		return false;
	}

	public bool TurnOff(GameObject toggler = null){
		return SetOn (false, toggler, false);
	}

	public bool TurnOn(GameObject toggler = null){
		return SetOn (true, toggler, false);
	}

//	public bool TurnOff(GameObject toggler = null){
//		if(lockout != null && toggler != lockout){
//			return false;
//		}
//		if(hasLightParticles){
//			lightParticles.SetActive (false);
//		}
//		lightSource.enabled = false;
//		if(isOn){
//			isOn = false;
//			return true;
//		}
//		return false;
//	}
//
//	public bool TurnOn(GameObject toggler = null){
//		if(lockout != null && toggler != lockout){
//			return false;
//		}
//		if(hasLightParticles){
//			lightParticles.SetActive (true);
//		}
//		lightSource.enabled = true;
//		if(!isOn){
//			isOn = true;
//			return true;
//		}
//		return false;
//	}

	public bool SetLockout(GameObject locker){
		if(lockout == null){
			lockout = locker;
			return true;
		}
		return false;
	}

	public bool FreeLockout(GameObject locker){
		if(lockout == locker){
			lockout = null;
			return true;
		}
		return false;
	}
}
