using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerObjectInteraction : MonoBehaviour {
	/*
	List<InteractableObject> responders = new List<InteractableObject>();
	[SerializeField] float reach = 4f;
	[SerializeField] LayerMask mask;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GetResponders();
			SendInteractionStart();
		}
		if (Input.GetMouseButton (0)) {
			SendInteractionContinue();
		}
		if (Input.GetMouseButtonUp (0)) {
			SendInteractionEnd();
			ClearResponders();
		}
	}

	void GetResponders(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, reach, mask)){
			Transform hitTransform = hit.transform;
			responders.AddRange(hitTransform.gameObject.GetComponents<InteractableObject>());
			FindRespondersInChildren(hitTransform);
			//print (responders.Count);
		}
	}

	void FindRespondersInChildren(Transform parent){
		for (int i = 0; i < parent.childCount; i++) {
			Transform child = parent.GetChild(i);
			responders.AddRange(child.gameObject.GetComponents<InteractableObject>());
			FindRespondersInChildren(child);
		}
	}

	void SendInteractionStart(){
		foreach(InteractableObject responder in responders){
			responder.InteractionStart(gameObject);
		}
	}

	void SendInteractionContinue(){
		foreach(InteractableObject responder in responders){
			responder.InteractionContinue(gameObject);
		}
	}

	void SendInteractionEnd(){
		foreach(InteractableObject responder in responders){
			responder.InteractionEnd(gameObject);
		}
	}

	void ClearResponders(){
		responders.Clear();
	}

	//If an object becomes no longer interactible, it will call this message on all interactors.
	public void NoLongerInteractable(GameObject responderObject){
		InteractableObject[] responses = responderObject.GetComponents<InteractableObject> ();
		foreach (InteractableObject responder in responses) {
			if(responders.Contains(responder)){
				responders.Remove(responder);
			}
		}
	}
	*/
}
