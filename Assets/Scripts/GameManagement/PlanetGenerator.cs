using UnityEngine;
using System.Collections;

public class PlanetGenerator : MonoBehaviour {
	public GameObject[] planets;

	void Start() {
		InvokeRepeating("SpawnPlanet", 0, Random.Range(1, 10));
	}

	void SpawnPlanet() {
		Instantiate(planets[Random.Range(0, planets.Length)], new Vector2(transform.position.x, transform.position.y + Random.Range(-8f, 8f)), transform.rotation);
	}
}
