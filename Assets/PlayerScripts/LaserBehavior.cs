using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {

	void FixedUpdate () {
		gameObject.transform.Translate(15f * Time.deltaTime, 0f, 0f);	
	}

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Asteroid") {
			other.gameObject.SendMessage("GetRekt");
		}
	}
}
