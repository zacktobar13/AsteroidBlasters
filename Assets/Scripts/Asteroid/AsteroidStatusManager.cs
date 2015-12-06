using UnityEngine;
using System.Collections;

public class AsteroidStatusManager : MonoBehaviour {

	public GameObject asteroidPieces, shield;
	GameObject scoreManager;

	void Start() {
		scoreManager = GameObject.FindWithTag("ScoreManager");
	}

	public void GetRekt() {
		int chanceForShield = Random.Range(0, 100);
		if(chanceForShield < 2) {
			Instantiate(shield, transform.position, transform.rotation);
		}

		Destroy(Instantiate(asteroidPieces, gameObject.transform.position, gameObject.transform.rotation), .5f);
		Destroy(gameObject);
		scoreManager.SendMessage("AddPoints", 5);
	}
	
}
