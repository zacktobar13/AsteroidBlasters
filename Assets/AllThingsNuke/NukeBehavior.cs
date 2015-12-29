using UnityEngine;
using System.Collections;

public class NukeBehavior : MonoBehaviour {
	
	float speed = 20f;

	void FixedUpdate () {
		transform.Translate(Vector3.right * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Asteroid") {
			other.gameObject.SendMessage("DeathByNuke");
		}
	}

}
