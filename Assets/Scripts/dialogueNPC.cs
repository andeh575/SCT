using UnityEngine;
using System.Collections;

public class dialogueNPC : MonoBehaviour {

	public string[] answers;	// Things that the NPC could say
	public string[] dialogue;	// Replies available to the player
	public Rect windowRect = new Rect (750, 600, 400, 100); // Some formatting for the dialogue window
	bool displayDialogue = false;	// Interaction toggle
	bool triggerDialogue = false;	// Proximity trigger


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Let's make sure that the player is trying to interact with us - also acts as an escape
		if (Input.GetKeyDown (KeyCode.E)) {	
			toggleDialogue();
		}
	}

	// Let's display a GUI for the dialogue
	void OnGUI() {
		if (triggerDialogue && displayDialogue) { // Ensure we're close enough and the player explicitly wants to initiate dialogue
			windowRect = GUILayout.Window (0, windowRect, windowOpts, "NPC");
		}
	}

	// The interior of our dialogue window
	void windowOpts(int ID) {
		GUILayout.Label (dialogue [0]);
			
		if (GUILayout.Button (answers [0])) {
			displayDialogue = false;
		}

	}

	// Player has interacted with this object
	void toggleDialogue() {
		displayDialogue = !displayDialogue;
	}

	// Player must be close enough to initiate dialogue
	void OnTriggerEnter(){
		triggerDialogue = true;
	}

	// Exit dialogue if the player walks away
	void OnTriggerExit() {
		triggerDialogue = false;
		displayDialogue = false;
	}
}