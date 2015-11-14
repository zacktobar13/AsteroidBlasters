using UnityEngine;
using System.Collections;

public class PlayerPiecesMovement : MonoBehaviour {

	bool firstTime = true;
	float x;
	float y;

	void Start() {
		x = Random.Range(-.03f, .03f);
		y = Random.Range(-.03f, .03f);
	}

	void FixedUpdate () {
		gameObject.transform.Translate(x, y, 0f);

		if (firstTime) {
			StartCoroutine("DestroySelf", 1f);
			firstTime = false;
		}
	}

	IEnumerator DestroySelf(float time) {
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
