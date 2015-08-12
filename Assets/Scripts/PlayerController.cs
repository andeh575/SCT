using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))] 

// Simple player movement with WASD/Arrow Keys
public class PlayerController : MonoBehaviour {

	public float baseSpeed = 3;
	public float rotSpeed = 3;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Forward movement and speed of the player
		Vector3 forward = transform.TransformDirection (0, 0, 1);
		float currentSpeed = baseSpeed * moveVertical;  

		// Rotational facing of the player
		transform.Rotate (0, moveHorizontal * rotSpeed, 0);

		// Let's move forward in the direction we're currently facing
		controller.SimpleMove (forward * currentSpeed);
	}
}