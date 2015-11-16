using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {
	float x;
	float y;

	void Start () {
		x = Random.Range(-15f, -8f) * Time.deltaTime;
		y = Random.Range(-5, 5) * Time.deltaTime;
	}
	
	void Update () {
		transform.Translate(x, y, 0f);
	}
}
