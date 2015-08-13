using UnityEngine;
using System.Collections;

public class spawnPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = (GameObject.Find("Spawner").transform.position) + Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}