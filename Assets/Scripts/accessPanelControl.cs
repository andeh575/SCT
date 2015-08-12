using UnityEngine;
using System.Collections;

public class accessPanelControl : MonoBehaviour {

	public enum State {
		on,		// Panel is active - doors are open
		off		// Panel is inactive - doors are closed
	}

	public State state;

	// Use this for initialization
	void Start () {
		this.state = accessPanelControl.State.off;	// All panels are off by default
	}
	
	// Update is called once per frame
	void Update () {
		// Check to ensure this object is interactable and that the interact key ('e') was pressed
		if (Input.GetKeyUp (KeyCode.E) && this.gameObject.GetComponent<Interactable>().interact) {
			if (state == accessPanelControl.State.on){	// The panel was on so let's turn it off
				Off ();
			}
			else {	// The panel was off so let's turn it on
				On ();	
			}
		}
	}

	// Panel is activated - Open door
	private void On() {
		state = accessPanelControl.State.on;
		Debug.Log (state);
	}

	// Panel is deactivated - Close door
	private void Off() {
		state = accessPanelControl.State.off;
		Debug.Log (state);
	}
}

/*GameObject.Find("AccessPanel").GetComponent<Interactable>().interact*/