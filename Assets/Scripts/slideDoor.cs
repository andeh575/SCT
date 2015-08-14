using UnityEngine;
using System.Collections;

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
		if (aPanel.GetComponent<accessPanel> ().state == accessPanel.State.on && state == slideDoor.State.closed) {
			state = slideDoor.State.animating;
			StartCoroutine("Open");
		} else if (aPanel.GetComponent<accessPanel> ().state == accessPanel.State.off && state == slideDoor.State.open) {
			state = slideDoor.State.animating;
			StartCoroutine("Close");
		}
	}

	// Open the door
	private IEnumerator Open() {
		anim.Play ("slideDoorOpen");

		// Force player to wait for animation to finish
		aPanel.GetComponent<accessPanel> ().controlFlag = false;
		yield return new WaitForSeconds (GetComponent<Animation>() ["slideDoorOpen"].length);
		aPanel.GetComponent<accessPanel> ().controlFlag = true;
		state = slideDoor.State.open;
	}

	// Close the door
	private IEnumerator Close() {
		anim.Play ("slideDoorClosed");

		// Force player to wait for animation to finish
		aPanel.GetComponent<accessPanel> ().controlFlag = false;
		yield return new WaitForSeconds (GetComponent<Animation>() ["slideDoorClosed"].length);
		aPanel.GetComponent<accessPanel> ().controlFlag = true;
		state = slideDoor.State.closed;
	}
}
