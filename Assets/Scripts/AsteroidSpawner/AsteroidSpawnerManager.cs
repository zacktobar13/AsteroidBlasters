using UnityEngine;
using System.Collections;

public class AsteroidSpawnerManager : MonoBehaviour {

	float gameTime;
	float totalTime;
	public GameObject ScoreManager;
	GameObject[] asteroidSpawners;
	public GameObject player;

	void Start () {
		asteroidSpawners = GameObject.FindGameObjectsWithTag("AsteroidSpawner");
		ScoreManager = GameObject.FindWithTag("ScoreManager");
	}

	void OnEnable() {
		totalTime = Time.time;
		gameTime = Time.time - totalTime;
		InvokeRepeating("AddPoints", 3, 1f);
	}

	void OnDisable() {
		CancelInvoke();
	}

	void AddPoints() {
		ScoreManager.SendMessage("AddPoints", 3);
	}
	
	void Update () {
		if (ShouldSpawnAsteroid()) {
			SpawnAsteroid();
		}
	}

	void FixedUpdate() {
		gameTime = Time.time - totalTime;
		if (gameTime % 15 < 1) {
			GameObject[] allAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
			foreach (GameObject asteroid in allAsteroids) {
				asteroid.SendMessage("GetRekt");
			}
		}
	}

	void SpawnAsteroid() {
		asteroidSpawners[Random.Range(0, asteroidSpawners.Length)].SendMessage("SpawnAsteroid");
	}

	bool ShouldSpawnAsteroid() {
		return isEqual(Mathf.Cos(gameTime * 3f) / (gameTime * 1.7f), 0f, .002f);
	}

	bool isEqual(float x, float y, float tolerance) {
		float difference = Mathf.Abs(x - y);
		if (difference < tolerance) {
			return true;
		}
		return false;
	}

}
