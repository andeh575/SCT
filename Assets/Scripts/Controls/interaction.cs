using UnityEngine;
using System.Collections;

// Simple interaction script based on proximity collisions
public class interaction : MonoBehaviour {

	private bool triggerDialogue;	// NPC Dialogue trigger
	private bool triggerPanel;		// Access Panel trigger
	private string target;			// Placeholder for collider tag
	private Collider interactable;	// Placeholder for collider we're interacting with

	// Use this for initialization
	void Start () {
		triggerDialogue = false;
		triggerPanel = false;
	}
	
	// Update is called once per frame
	void Update () {

		// Player interaction ('e')
		if (Input.GetKeyUp (KeyCode.E)) {

			// Is the object an NPC with dialogue?
			if(triggerDialogue && interactable) {
				interactable.GetComponent<dialogueNPC>().Action();
			}
			// is the object an Access Panel?
			else if (triggerPanel && interactable) {
				interactable.GetComponent<accessPanel>().Action();
			}
		}

		// Allow the player to exit the game with the ESC key
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	// Detecting proximity with interactible game objects
	public void OnTriggerEnter (Collider obj) {

		// Is the player next to something we can interact with?
		target = obj.tag.ToString();
		
		// Player in proximity with an access panel
		if(target.Equals("access_panel")) {
			triggerPanel = !triggerPanel;
			interactable = obj;

			// Call to the accessPanel to make proximity TRUE
			interactable.GetComponent<accessPanel>().TriggerFlag = true;
		}
		// Player in proximity with an npc that they can talk to
		else if (target.Equals("npc_dialogue")) {
			triggerDialogue = !triggerDialogue;
			interactable = obj;

			// Call to the dialogueNPC to make proximity TRUE
			interactable.GetComponent<dialogueNPC>().TriggerDialogue = true;
		}
	}
	
	// Detecting movement away from interactible game objects
	private void OnTriggerExit (Collider obj) {

		// Just in case leaving this object prompts something special
		target = obj.tag.ToString();

		if(target.Equals("access_panel")) {
			triggerPanel = !triggerPanel;

			// Call to the accessPanel to make proximity FALSE
			obj.GetComponent<accessPanel>().TriggerFlag = false;
			interactable = null;
			target = "";
		}
		else if (target.Equals("npc_dialogue")) {
			triggerDialogue = !triggerDialogue;

			// Call to the dialogueNPC to make proximity FALSE
			obj.GetComponent<dialogueNPC>().TriggerDialogue = false;
			interactable = null;
			target = "";
		}
	}
}
