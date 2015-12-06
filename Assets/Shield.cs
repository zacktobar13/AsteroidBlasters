using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	float speed = 7;

	//Movement is a constant speed to the left.
	void Update() {
		transform.Translate(Vector3.left * Time.deltaTime * speed);
	}

	//Destroy self when player is hit.
	void OnTriggerEnter2D(Collider2D otherObject) {
		if(otherObject.gameObject.tag == "Player") {
			otherObject.gameObject.SendMessage("ActivateShield");
			Destroy(gameObject);
		}
	}
}
