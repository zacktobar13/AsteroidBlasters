﻿using UnityEngine;
using System.Collections;

public class AsteroidSpawnerManager : MonoBehaviour {

	/* "Time" here isn't actually the game time, it's a more fixed rate
	*  of how long the current game has been going */

	public const int MAX_SPAWN_RATE = 1;
	float gameTime;
	GameObject[] asteroidSpawners;
	

	public void StartOfGame() {
		gameTime = Time.time;
	}

	void Start () {
		gameTime = Time.time;
		asteroidSpawners = GameObject.FindGameObjectsWithTag("AsteroidSpawner");
	}
	
	void Update () {
		gameTime = Time.time;
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