using UnityEngine;
using System.Collections;

public class PlanetMovement : MonoBehaviour {

	float movementSpeed;

	void Start() {
		movementSpeed = Random.Range(-10f, -6f);
	}

	void Update() {
		transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
	}
/*
	void OnBecameInvisible() {
		Destroy(gameObject);
	}*/
}
