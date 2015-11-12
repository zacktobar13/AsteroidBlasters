using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Translate(Random.Range(-.08f, -.18f), 0f, 0f);
	}
}
