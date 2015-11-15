using UnityEngine;
using System.Collections;

public class AsteroidSpawnerBehavior : MonoBehaviour {
	
	public GameObject[] asteroids;

	public void SpawnAsteroid() {
		GameObject asteroidToSpawn = asteroids[Random.Range(0, asteroids.Length)];
		Destroy(Instantiate(asteroidToSpawn, transform.position, transform.rotation), 10f);
	}
}
