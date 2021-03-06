﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))] 

// Simple player movement with WASD/Arrow Keys amd helper functions
public class PlayerController : MonoBehaviour {

	private float baseSpeed = 5;
	public bool disableMove = false; 	// External movement flag
	private bool toggleMove = true;		// Internal movement toggle - default true: accepts requests to freeze player
	private float moveHorizontal;		// Player rotational direction
	private float moveVertical;			// Player forward movement
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (disableMove && toggleMove) {	// Internal and External flags are set to freeze player movement
			Input.ResetInputAxes(); 		// Only blocks movement, mouse still OK
		} else { 							// Let's NOT lock the player's movement
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");

			// Forward movement and speed of the player
			Vector3 forward = transform.TransformDirection (0, 0, 1);
			float currentSpeed = baseSpeed * moveVertical;  
			
			// Rotational facing of the player
			transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, 
			                                       (transform.rotation.eulerAngles.y + 100f * Time.deltaTime * moveHorizontal), 
			                                       transform.rotation.eulerAngles.z);
			
			// Let's move forward in the direction we're currently facing
			controller.SimpleMove (forward * currentSpeed);
		}

	}

	// Toggle: lock player movement
	public void togglePlayerMove () {
		if (toggleMove) {
			disableMove = !disableMove;
		}
	}

}