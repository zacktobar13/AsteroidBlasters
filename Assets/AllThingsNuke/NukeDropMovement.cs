using UnityEngine;
using System.Collections;

public class NukeDropMovement : MonoBehaviour {

	GameObject nukeSpawner;
	float speed = 7;

	void Update() {
		nukeSpawner = GameObject.FindGameObjectWithTag("NukeSpawner");
		transform.Translate(Vector3.left * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D otherObject) {
		if(otherObject.gameObject.tag == "Player") {
			nukeSpawner.SendMessage("SpawnNuke");
			Destroy(gameObject);
		}
	}
}
