using UnityEngine;
using System.Collections;

// Animate a sliding door
public class slideDoor : MonoBehaviour {

	public enum State {
		open,		
		closed,	
		animating
	}

	public State state;
	public GameObject aPanel;
	private Animation anim;

	// Use this for initialization
	void Start () {
		state = slideDoor.State.closed;
		anim = gameObject.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		// If the panel has been turned ON and the door is closed then it should open
		if (aPanel.GetComponent<accessPanel> ().state == accessPanel.State.on && state == slideDoor.State.closed) {
			state = slideDoor.State.animating; // Ensure the animation doesn't get interrupted
			StartCoroutine("Open");
		} 
		// If the panel has been turned OFF and the door is open then it should close
		else if (aPanel.GetComponent<accessPanel> ().state == accessPanel.State.off && state == slideDoor.State.open) {
			state = slideDoor.State.animating;	// Ensure the animation doesn't get interrupted
			StartCoroutine("Close");
		}
	}

	// Open the door
	private IEnumerator Open() {
		anim.Play ("slideDoorOpen");

		// Force player to wait for animation to finish
		aPanel.GetComponent<accessPanel> ().ControlFlag = false;
		yield return new WaitForSeconds (GetComponent<Animation>() ["slideDoorOpen"].length);
		aPanel.GetComponent<accessPanel> ().ControlFlag = true;
		state = slideDoor.State.open;
	}

	// Close the door
	private IEnumerator Close() {
		anim.Play ("slideDoorClosed");

		// Force player to wait for animation to finish
		aPanel.GetComponent<accessPanel> ().ControlFlag = false;
		yield return new WaitForSeconds (GetComponent<Animation>() ["slideDoorClosed"].length);
		aPanel.GetComponent<accessPanel> ().ControlFlag = true;
		state = slideDoor.State.closed;
	}
}
