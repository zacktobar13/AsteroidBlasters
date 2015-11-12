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
				if (OnFireButton(touch)) {
					gameObject.SendMessage("FireLaser");
				} else {
					numTouching += 1;
				}
			} else if (touch.phase == TouchPhase.Ended && !OnFireButton(touch)) {
				numTouching -= 1;
			}
		}

		isTouching = numTouching > 0;
	}

	void FixedUpdate() {
		if (isTouching) {
			rigidBody.AddForce(new Vector2(0, 20));
		}
	}

	bool OnFireButton(Touch touch) {
		if (touch.position.x < 150 && touch.position.y < 150) {
			return true;
		}
		return false;
	}
}
