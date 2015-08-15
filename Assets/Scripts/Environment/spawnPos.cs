using UnityEngine;
using System.Collections;

// Simple class to create a spawn area
public class spawnPos : MonoBehaviour {

	public GameObject spawner;

	// Use this for initialization
	void Start () {
		// Create the item within a random unit sphere around the Spawner
		transform.position = (spawner.transform.position) + (Random.insideUnitSphere / 2);
	}

}