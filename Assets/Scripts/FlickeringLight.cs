using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Light))]
public class FlickeringLight : MonoBehaviour {

	public float flickerTime = 0.1f;			//The average time between light flickers.
	public float maxBrightnessChange = 0.9f;	//The maximum amount that the light can dim or brighten.
	public float dimSpeed = 1f;					//The rate the brightness of the light will change when it flickers.
	public float maxDisplacement = 0.02f;		//The maximum distance the light source can be moved from its origin.
	public float displacementSpeed = 1f;		//The rate that the light will move when it flickers.
	public Light targetLight;					//The light that should flicker. If no lights are specified, the script
												// will use a light on the game object.

	private Vector3 origin;
	private float baseBrightness;
	private float brightnessSuppression = 1.0f;

	private Vector3 currentPosition;
	private Vector3 targetPosition;
	private float currentBrightness;
	private float targetBrightness;
	private float timer = 0;
	private float nextFlickerTime;

	// Use this for initialization
	void Start () {
		if (targetLight != null) {
			Setup ();
		} else {
			targetLight = GetComponent<Light> ();
			if(targetLight != null){
				Setup ();
			}
		}
		nextFlickerTime = flickerTime;
	}

	void Setup(){
		origin = targetLight.transform.localPosition;
		baseBrightness = targetLight.intensity;

		currentPosition = origin;
		targetPosition = origin;
		currentBrightness = baseBrightness;
		targetBrightness = baseBrightness;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(timer >= nextFlickerTime){
			Flicker();
			timer = 0f;
			nextFlickerTime = (Random.value * flickerTime) + (flickerTime / 2);
		}
		Transition ();
		ShiftLight ();
	}

	void Flicker(){
		targetPosition = origin + (Random.insideUnitSphere * maxDisplacement);
		targetBrightness = (baseBrightness + (Random.Range(-1, 1) * maxBrightnessChange)) * brightnessSuppression;
	}

	void Transition(){
		currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * displacementSpeed);
		currentBrightness = Mathf.Lerp (currentBrightness, targetBrightness, Time.deltaTime * dimSpeed);
	}

	void ShiftLight(){
		targetLight.transform.localPosition = currentPosition;
		targetLight.intensity = currentBrightness;
	}

	public void SetBrightnessSuppression(float percentBrightness){
		float safeBrightness = percentBrightness;
		if (safeBrightness > 1) {
			safeBrightness = 1;
		} else if (safeBrightness < 0) {
			safeBrightness = 0;
		}
		brightnessSuppression = safeBrightness;
	}
}
