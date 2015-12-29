using UnityEngine;
using System.Collections;

public class NukeDropMovement : MonoBehaviour {
	GameObject nukeSpawner; 
	NukeAnimation nukeAnimation;
	float speed = 7;

	void Awake() {
		nukeSpawner = GameObject.FindGameObjectWithTag("NukeSpawner");
		nukeAnimation = GameObject.Find("NukeFlash").GetComponent<NukeAnimation>();
	}

	void Update() {	
		transform.Translate(Vector3.left * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D otherObject) {
		if(otherObject.gameObject.tag == "Player") {
			nukeSpawner.SendMessage("SpawnNuke");
			nukeAnimation.NukeExplodeAnimation();
			Destroy(gameObject);
		}
	}
}
