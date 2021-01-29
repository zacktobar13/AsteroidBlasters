using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {

	void FixedUpdate () {
		gameObject.transform.Translate(25f * Time.deltaTime, 0f, 0f);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Asteroid") {
			other.gameObject.SendMessage("Death");
			Destroy(gameObject);
		}
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
