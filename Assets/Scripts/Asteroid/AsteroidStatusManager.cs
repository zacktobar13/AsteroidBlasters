using UnityEngine;
using System.Collections;

public class AsteroidStatusManager : MonoBehaviour {

	public GameObject asteroidPieces, shield, nuke;
	GameObject scoreManager;
	public float shieldSpawnChance;
	public float nukeSpawnChance;

	void Start() {
		scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
	}

	public void GetRekt() {
		float dropNumber = Random.Range(0f, 100f);
		if(dropNumber < shieldSpawnChance) {
			Destroy(Instantiate(shield, transform.position, transform.rotation), 10f);
		} else if (dropNumber > 100 - nukeSpawnChance) {
			Destroy(Instantiate(nuke, transform.position, transform.rotation), 10f);
		}

		Destroy(Instantiate(asteroidPieces, gameObject.transform.position, gameObject.transform.rotation), .5f);
		Destroy(gameObject);
		scoreManager.SendMessage("AddPoints", 5);
	}

	public void DeathByNuke() {
		float dropNumber = Random.Range(0f, 100f);
		if(dropNumber < shieldSpawnChance) {
			Destroy(Instantiate(shield, transform.position, transform.rotation), 10f);
		} else if (dropNumber > 100 - nukeSpawnChance) {
			Destroy(Instantiate(nuke, transform.position, transform.rotation), 10f);
		}
		scoreManager.SendMessage("AddPoints", 5);
		Destroy(gameObject);
	}
	
}
