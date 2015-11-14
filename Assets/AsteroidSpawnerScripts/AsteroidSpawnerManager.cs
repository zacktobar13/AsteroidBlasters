using UnityEngine;
using System.Collections;

public class AsteroidSpawnerManager : MonoBehaviour {

	public const int MAX_SPAWN_RATE = 1;
	float gameTime;
	float totalTime;
	GameObject[] asteroidSpawners;

	void Start () {
		asteroidSpawners = GameObject.FindGameObjectsWithTag("AsteroidSpawner");
	}

	void OnEnable() {
		totalTime = Time.time;
		gameTime = Time.time - totalTime;
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
		return isEqual(Mathf.Cos(gameTime * 3f) / gameTime, 0f, .002f);
	}

	bool isEqual(float x, float y, float tolerance) {
		float difference = Mathf.Abs(x - y);
		if (difference < tolerance) {
			return true;
		}
		return false;
	}

}
