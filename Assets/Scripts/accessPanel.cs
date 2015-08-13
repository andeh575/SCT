using UnityEngine;
using System.Collections;

public class accessPanel : MonoBehaviour {

	public enum State {
		on,		// Panel is active - doors are open
		off		// Panel is inactive - doors are closed
	}

	public State state;					// Is the panel on or off?
	public bool triggerFlag = false;	// Proximity trigger
	public bool controlFlag = true;		// Special trigger: ie animations

	// Use this for initialization
	void Start () {
		this.state = accessPanel.State.off; // All panels off by default
	}

	// Update is called once per frame
	void Update () {
		// Check to ensure player is within proximity, interact key ('e') was pressed,
		// and we're not waiting for something else (ie: animations)
		if (Input.GetKeyUp (KeyCode.E) && triggerFlag && controlFlag) {
			if (state == accessPanel.State.on){	
				Off ();	// The panel was on so let's turn it off
			}
			else {	
				On ();	// The panel was off so let's turn it on
			}
		}
	}

	// Activate the panel
	private void On() {
		this.state = accessPanel.State.on;
	}

	// Deactivate the panel
	private void Off() {
		this.state = accessPanel.State.off;
	}

	// Player must be close enough to interact
	private void OnTriggerEnter(Collider target) {
		if (target.tag.Equals("Player")) {
			this.triggerFlag = true;
		}
	}

	// Player walked too far away from the object - only works if movement during dialogue enabled
	private void OnTriggerExit(Collider target) {
		if (target.tag.Equals("Player")) {
			this.triggerFlag = false;
		}
	}
}
