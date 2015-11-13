using UnityEngine;
using System.Collections;

public class AsteroidSpawnerBehavior : MonoBehaviour {

	/* Eventually we will have an array of different asteroids that can
	*  be spawned, but for now its just this one. */

	public GameObject asteroid;

	public void SpawnAsteroid() {
		Destroy(Instantiate(asteroid, transform.position, transform.rotation), 10f);
	}
}
