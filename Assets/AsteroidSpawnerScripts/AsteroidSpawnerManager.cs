using UnityEngine;
using System.Collections;

public class AsteroidSpawnerManager : MonoBehaviour {

	/* "Time" here isn't actually the game time, it's a more fixed rate
	*  of how long the current game has been going */

	int lastAsteroidSpawnTime, gameTime = 0;
	int asteroidSpawnRate;
	public const int MAX_SPAWN_RATE = 15, MIN_SPAWN_RATE = 1;
	GameObject[] asteroidSpawners;
	

	public void StartOfGame() {
		gameTime = 0;
		CalculateSpawnRate();
	}

	void Start () {
		asteroidSpawners = GameObject.FindGameObjectsWithTag("AsteroidSpawner");
		InvokeRepeating("UpdateGameTime", 0f, 1f);
	}
	
	void Update () {
		if (gameTime - lastAsteroidSpawnTime > asteroidSpawnRate) {
			SpawnAsteroid();
		}
	}

	void SpawnAsteroid() {
		asteroidSpawners[Random.Range(0, asteroidSpawners.Length)].SendMessage("SpawnAsteroid");
		lastAsteroidSpawnTime = gameTime;
	}

	void UpdateGameTime() {
		gameTime += 1;
		CalculateSpawnRate();
	}

	void CalculateSpawnRate() {
		if (asteroidSpawnRate < MAX_SPAWN_RATE) {
			asteroidSpawnRate = gameTime / 1000;
			if (asteroidSpawnRate < MIN_SPAWN_RATE) {
				asteroidSpawnRate = MIN_SPAWN_RATE;
			}
		} else {
			return;
		}
	}
}
