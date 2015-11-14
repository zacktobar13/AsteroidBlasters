using UnityEngine;
using System.Collections;

public class AsteroidPiecesMovement : MonoBehaviour {
	
	bool firstTime = true;
	float x;
	float y;

	void Start() {
		x = Random.Range(-.09f, .09f);
		y = Random.Range(-.09f, .09f);
	}

	void FixedUpdate () {
		gameObject.transform.Translate(x, y, 0f);

		if (firstTime) {
			StartCoroutine("DestroySelf", .5f);
			firstTime = false;
		}
	}

	IEnumerator DestroySelf(float time) {
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
