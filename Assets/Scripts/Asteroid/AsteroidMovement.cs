using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {
	float x;
	float y;

	void Start () {
		x = Random.Range(-10f, -8f) * Time.deltaTime;
		y = Random.Range(-4, 4) * Time.deltaTime;
	}
	
	void Update () {
		transform.Translate(x, y, 0f);
	}
}
