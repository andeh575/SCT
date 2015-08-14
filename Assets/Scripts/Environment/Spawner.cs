using UnityEngine;
using System.Collections;

// Simple item spawning interface
public class Spawner : MonoBehaviour {

	public GameObject spawned;
	public GameObject aPanel;
	private bool isCreated;

	// Use this for initialization
	void Start () {
		isCreated = false;
	}
	
	// Update is called once per frame
	void Update () {
		// The accessPanel has been turned ON
		if(aPanel.GetComponent<accessPanel>().state == accessPanel.State.on) {
			// Create just ONE item per interaction with the accessPanel
			if(!isCreated) {
				Instantiate (spawned); 
				isCreated = true;
			}

			// Reset the accessPanel
			aPanel.GetComponent<accessPanel>().state = accessPanel.State.off;
			isCreated = false;
		}
	}

}