using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Random.Range(-8f, -10f) * Time.deltaTime, 0f, 0f);
	}
}
