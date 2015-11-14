using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	bool isTouching;
	int numTouching;
	Rigidbody2D rigidBody;

	bool mainMenu;

	void Start () {
		isTouching = false;
		numTouching = 0;
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void OnEnable() {
		transform.position = new Vector2(-7.6f, 0f);
	}

	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				if (OnFireButton(touch.position)) {
					gameObject.SendMessage("FireLaser");
				} else {
					numTouching += 1;
				}
			} else if (touch.phase == TouchPhase.Ended && 
								(! OnFireButton(touch.position - touch.deltaPosition))) {
				numTouching -= 1;
				if (numTouching < 0) {
					numTouching = 0;
				}
			}
		}
		isTouching = numTouching > 0;
		if (Input.touches.Length == 0) {
			isTouching = false;
			numTouching = 0;
		}
	}

	void FixedUpdate() {
		if (isTouching) {
			rigidBody.AddForce(new Vector2(0, 20));
		}
	}

	bool OnFireButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .8 && touchPos.y < Screen.height * .2) {
			return true;
		}
		return false;
	}
}
