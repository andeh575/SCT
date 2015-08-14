using UnityEngine;
using System.Collections;

public class dialogueNPC : MonoBehaviour {

	public string[] answers;		// Things that the NPC could say
	public string[] dialogue;		// Replies available to the player
	public Rect windowRect = new Rect (	750, 400, 400, 150); // Some formatting for the dialogue window
	bool displayDialogue = false;	// Interaction toggle
	bool triggerDialogue = false;	// Proximity trigger
	float native_width = 1920;
	float native_height = 1080;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Let's make sure that the player is trying to interact with us
		// and that the player is close enough
		if (Input.GetKeyUp (KeyCode.E) && triggerDialogue) {	
			toggleDialogueOn();	// 
			togglePlayerMove(); // Attempt to freeze the player's movement
		}
	}

	// Let's display a GUI for the dialogue
	private void OnGUI() {
		float rx = Screen.width / native_width;
		float ry = Screen.height / native_height; 
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (rx, ry, 1));

		// Ensure we're close enough and the player explicitly wants to initiate dialogue
		if (displayDialogue) { 
			windowRect = GUILayout.Window (0, windowRect, windowOpts, "NPC");
			//Debug.Log("Display Dialogue");
		}
	}

	// The interior of our dialogue window
	private void windowOpts(int ID) {
		GUILayout.Label (dialogue [0]);
			
		if (GUILayout.Button (answers [0])) {
			displayDialogue = false;
			togglePlayerMove(); // Unfreeze player's mvoement
		}

	}

	// Player has interacted with this object
	private void toggleDialogueOn() {
		displayDialogue = true;
	}

	// Player must be close enough to initiate dialogue
	private void OnTriggerEnter(Collider target){
		if (target.tag.Equals("Player")) {
			triggerDialogue = true;
		}
	}
	
	// Exit dialogue if the player walks away
	private void OnTriggerExit(Collider target) {
		if (target.tag.Equals("Player")) {
			triggerDialogue = false;
			displayDialogue = false;
		}
	}

	// Attempt to toggle player's ability to move during dialogue
	private void togglePlayerMove() {
		GameObject.Find("Player").GetComponent<PlayerController>().disableMove = !GameObject.Find("Player").GetComponent<PlayerController>().disableMove;
	}

}