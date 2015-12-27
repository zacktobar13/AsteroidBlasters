using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	ScoreManager scoreManager;
	float speed = 7;

	void OnEnable() {
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
	}

	//Movement is a constant speed to the left.
	void Update() {
		transform.Translate(Vector3.left * Time.deltaTime * speed);
	}

	//Destroy self when player is hit.
	void OnTriggerEnter2D(Collider2D otherObject) {
		if(otherObject.gameObject.tag == "Player") {
			scoreManager.AddPoints(50);
			otherObject.gameObject.SendMessage("ActivateShield");
			Destroy(gameObject);
		}
	}
}
