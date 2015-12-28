using UnityEngine;
using System.Collections;

public class AsteroidStatusManager : MonoBehaviour {

	public GameObject asteroidPieces, shield;
	GameObject scoreManager;
	public int shieldSpawnChance;

	void Start() {
		scoreManager = GameObject.FindWithTag("ScoreManager");
	}

	public void GetRekt() {
		int chanceForShield = Random.Range(0, 100);
		if(chanceForShield < shieldSpawnChance) {
			Instantiate(shield, transform.position, transform.rotation);
		}

		Destroy(Instantiate(asteroidPieces, gameObject.transform.position, gameObject.transform.rotation), .5f);
		Destroy(gameObject);
		scoreManager.SendMessage("AddPoints", 5);
	}

	public void DeathByNuke() {
		int chanceForShield = Random.Range(0, 100);
		if(chanceForShield < shieldSpawnChance) {
			Instantiate(shield, transform.position, transform.rotation);
		}
		scoreManager.SendMessage("AddPoints", 5);
		Destroy(gameObject);
	}
	
}
