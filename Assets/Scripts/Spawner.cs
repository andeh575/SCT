using UnityEngine;
using System.Collections;

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
		if(aPanel.GetComponent<accessPanel>().state == accessPanel.State.on) {
			if(!isCreated) {
				Instantiate (spawned);
				isCreated = true;
			}

			aPanel.GetComponent<accessPanel>().state = accessPanel.State.off;
			isCreated = false;
		}
	}

}