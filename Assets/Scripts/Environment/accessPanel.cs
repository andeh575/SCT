using UnityEngine;
using System.Collections;

// Generic class for all accessPanels - ability to interface with multiple objects
public class accessPanel : MonoBehaviour {

	public enum State {
		on,		// Panel is active - doors are open
		off		// Panel is inactive - doors are closed
	}

	public State state;			// Is the panel on or off?
	private bool triggerFlag;	// Proximity trigger
	private bool controlFlag;	// Special trigger: ie animations

	// Use this for initialization
	void Start () {
		state = accessPanel.State.off; // All panels off by default
		triggerFlag = false;
		controlFlag = true;
	}

	// We've been called to perform some action
	public void Action() {
		// Proximity AND we're not waiting on something special (ie: animation)
		if (triggerFlag && controlFlag) {
			if(state == accessPanel.State.on) {
				Off();	// Panel was on, so let's turn it off
			}
			else {
				On (); // Panel was off, so let's turn it on
			}
		}
	}
	
	// Activate the panel
	private void On() {
		state = accessPanel.State.on;
	}

	// Deactivate the panel
	private void Off() {
		state = accessPanel.State.off;
	}

	// triggerFlag accessor 
	public bool TriggerFlag {
		get	{
			return triggerFlag;
		}
		set {
			triggerFlag = value;
		}
	}

	// controlFlag accessor
	public bool ControlFlag {
		get {
			return controlFlag;
		}
		set {
			controlFlag = value;
		}
	}

}
