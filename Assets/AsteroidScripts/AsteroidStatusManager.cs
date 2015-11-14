using UnityEngine;
using System.Collections;

public class AsteroidStatusManager : MonoBehaviour {

	public GameObject asteroidPieces;
	GameObject scoreManager;

	void Start() {
		scoreManager = GameObject.FindWithTag("ScoreManager");
	}

	public void GetRekt() {
		Instantiate(asteroidPieces, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
		scoreManager.SendMessage("AddPoints", 5);
	}
	
}
