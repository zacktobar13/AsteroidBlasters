using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	bool isTouching;
	int numTouching;
	Rigidbody2D rigidBody;

	void Start () {
		isTouching = false;
		numTouching = 0;
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				numTouching += 1;
			} else if (touch.phase == TouchPhase.Ended) {
				numTouching -= 1;
			}
		}

		isTouching = numTouching > 0;

		if (isTouching) {
			rigidBody.AddForce(new Vector2(0, 100));
			Debug.Log("Tooching");
		} else {
			rigidBody.AddForce(new Vector2(0, -100));
		}
	}
}
