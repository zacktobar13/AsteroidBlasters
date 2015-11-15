using UnityEngine;
using System.Collections;

public class AsteroidStatusManager : MonoBehaviour {

	public GameObject asteroidPieces;
	GameObject scoreManager;

	void Start() {
		scoreManager = GameObject.FindWithTag("ScoreManager");
	}

	public void GetRekt() {
		Destroy(Instantiate(asteroidPieces, gameObject.transform.position, gameObject.transform.rotation), .5f);
		Destroy(gameObject);
		scoreManager.SendMessage("AddPoints", 5);
	}
	
}
