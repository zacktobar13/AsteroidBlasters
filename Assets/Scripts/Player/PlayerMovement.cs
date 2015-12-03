using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rigidBody;

	bool isTouching;
	bool mainMenu;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void OnEnable() {
		isTouching = false;
		transform.position = new Vector2(-7.6f, 0f);
	}

	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				if (OnFireButton(touch.position)) {
					gameObject.SendMessage("FireLaser");
				} else if (!isTouching) {
					isTouching = OnThrustButton(touch.position);
				}
			} else if (touch.phase == TouchPhase.Moved) {
				if (OnThrustButton(touch.position - touch.deltaPosition) && !OnThrustButton(touch.position)) {
					isTouching = false;
				}
			}
		}
		if (Input.touches.Length == 0) {
			isTouching = false;
		}
	}

	void FixedUpdate() {
		if (isTouching) {
			rigidBody.AddForce(new Vector2(0, 20));
		}
	}

	bool OnFireButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .7 && touchPos.y < Screen.height * .3) {
			return true;
		}
		return false;
	}

	bool OnThrustButton(Vector2 touchPos) {
		if (touchPos.x < Screen.width * .3 && touchPos.y < Screen.height * .3) {
			return true;
		}
		return false;
	}
}
