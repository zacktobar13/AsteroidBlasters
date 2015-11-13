using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	void Update () {
		transform.Translate(Random.Range(-12f, -14f) * Time.deltaTime, 0f, 0f);
	}
}
