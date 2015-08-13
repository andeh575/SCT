using UnityEngine;
using System.Collections;

public class destructTime : MonoBehaviour {

	public float timeSecs;

	// Use this for initialization
	void Start () {
		timeSecs = Random.Range (3, 5);	// Some random time between 3-5 secs
		Destroy (gameObject, timeSecs);	// Destroy this object
	}
}
