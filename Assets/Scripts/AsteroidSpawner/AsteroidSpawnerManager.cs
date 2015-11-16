using UnityEngine;
using System.Collections;

public class AsteroidSpawnerManager : MonoBehaviour {

	float gameTime;
	float totalTime;
	public GameObject ScoreManager;
	GameObject[] asteroidSpawners;

	void Start () {
		asteroidSpawners = GameObject.FindGameObjectsWithTag("AsteroidSpawner");
		ScoreManager = GameObject.FindWithTag("ScoreManager");
	}

	void OnEnable() {
		totalTime = Time.time;
		gameTime = Time.time - totalTime;
		InvokeRepeating("AddPoints", 0, 1f);
	}

	void OnDisable() {
		CancelInvoke();
	}

	void AddPoints() {
		ScoreManager.SendMessage("AddPoints", 3);
	}
	
	void Update () {
		gameTime = Time.time - totalTime;
		if (ShouldSpawnAsteroid()) {
			SpawnAsteroid();
		}
	}

	void SpawnAsteroid() {
		asteroidSpawners[Random.Range(0, asteroidSpawners.Length)].SendMessage("SpawnAsteroid");
	}

	bool ShouldSpawnAsteroid() {
		return isEqual(Mathf.Cos(gameTime * 3f) / (gameTime * 1.5f), 0f, .002f);
	}

	bool isEqual(float x, float y, float tolerance) {
		float difference = Mathf.Abs(x - y);
		if (difference < tolerance) {
			return true;
		}
		return false;
	}

}
