using UnityEngine;
using System.Collections;

public class AsteroidPiecesMovement : MonoBehaviour {
	bool firstTime = true;
	void FixedUpdate () {
		gameObject.transform.Translate(Random.Range(-.18f, .18f), Random.Range(-.18f, .18f), 0f);

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
