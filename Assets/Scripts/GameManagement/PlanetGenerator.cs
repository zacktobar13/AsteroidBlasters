using UnityEngine;
using System.Collections;

public class PlanetGenerator : MonoBehaviour {
	public GameObject[] planets;

	void Start() {
		InvokeRepeating("SpawnPlanet", Random.Range(5, 10), Random.Range(10, 20));
		InvokeRepeating("SpawnPlanet", Random.Range(5, 10), Random.Range(10, 20));
		InvokeRepeating("SpawnPlanet", Random.Range(5, 10), Random.Range(10, 20));
	}

	void SpawnPlanet() {
		Destroy(Instantiate(planets[Random.Range(0, planets.Length)], new Vector2(transform.position.x, transform.position.y + Random.Range(-8f, 8f)), transform.rotation), 7f);
	}
}
