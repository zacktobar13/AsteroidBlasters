using UnityEngine;
using System.Collections;

public class NukeDropMovement : MonoBehaviour {
	GameObject nukeSpawner; 
	NukeAnimation nukeAnimation;
	float speed = 7;
	MiscStatManager miscStatManager;

	void Awake() {
		miscStatManager = GameObject.Find("Canvas").GetComponent<MiscStatManager>();
		nukeSpawner = GameObject.FindGameObjectWithTag("NukeSpawner");
		nukeAnimation = GameObject.Find("NukeFlash").GetComponent<NukeAnimation>();
	}

	void Update() {	
		transform.Translate(Vector3.left * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D otherObject) {
		if(otherObject.gameObject.tag == "Player") {
			miscStatManager.nukesCollected += 1;
			nukeSpawner.SendMessage("SpawnNuke");
			nukeAnimation.NukeExplodeAnimation();
			Destroy(gameObject);
		}
	}
}
