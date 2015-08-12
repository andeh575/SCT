using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	public bool interact = false;	// Object is un-interactable by default

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// On mouse hover make the object interactable
	public void OnMouseEnter(){
		this.interact = true;
		Debug.Log (interact);
	}

	// Upon mouse exit put it back to un-interactable
	public void OnMouseExit(){
		this.interact = false;
		Debug.Log (interact);
	}	
}