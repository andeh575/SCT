using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dialogueNPC : MonoBehaviour {

	public GameObject dialogueBox;

	public string[] answers;		// Things that the NPC could say
	public string[] dialogue;		// Replies available to the player
	private bool displayDialogue;	// Interaction toggle
	private bool triggerDialogue;	// Proximity trigger



	// Use this for initialization
	void Start () {
		triggerDialogue = false;
		displayDialogue = false;
		dialogueBox.SetActive (false);
	}

	// We've been called to perform some action
	public void Action() {
		if (triggerDialogue) {
			togglePlayerMove();
			dialogueBox.SetActive(true);
		}

	}

	// Player has interacted with this object
	private void toggleDialogueOn() {
		displayDialogue = true;
	}

	// Attempt to toggle player's ability to move during dialogue
	private void togglePlayerMove() {
		GameObject.Find("Player").GetComponent<PlayerController>().disableMove = !GameObject.Find("Player").GetComponent<PlayerController>().disableMove;
	}

	// triggerDialogue accessor
	public bool TriggerDialogue {
		get { 
			return triggerDialogue;
		}
		set {
			triggerDialogue = value;
		}
	}

	// displayDialogue accessor
	public bool DisplayDialogue {
		get {
			return displayDialogue;
		}
		set {
			displayDialogue = value;
		}
	}

}