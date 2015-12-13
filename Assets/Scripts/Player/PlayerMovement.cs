using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rigidBody;

	bool isTouching;
	bool mainMenu;
	public Image thrustButton, laserButton;
	public Sprite buttonUnPressed, buttonPressed;
	bool firstMove;

	void Start () {
		rigidBody = this.GetComponent<Rigidbody2D>();
	}

	void OnEnable() {
		rigidBody = this.GetComponent<Rigidbody2D>();
		isTouching = false;
		transform.position = new Vector2(-7.6f, 0f);
		firstMove = true;
		rigidBody.isKinematic = true;
	}

	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				if (OnFireButton(touch.position)) {
					gameObject.SendMessage("FireLaser");
					StopAllCoroutines();
					StartCoroutine("FireButtonSpriteChange");
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
			if (firstMove) {
				rigidBody.isKinematic = false;
				firstMove = false;
			}
			rigidBody.AddForce(new Vector2(0, 16));
			thrustButton.sprite = buttonPressed;
		} else {
			thrustButton.sprite = buttonUnPressed;
		}
	}

	bool OnFireButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .7 && touchPos.y < Screen.height * .3) {
			return true;
		}
		return false;
	}

	public bool getFirstMove() {
		return firstMove;
	}

	bool OnThrustButton(Vector2 touchPos) {
		if (touchPos.x < Screen.width * .3 && touchPos.y < Screen.height * .3) {
			return true;
		}
		return false;
	}

	IEnumerator FireButtonSpriteChange() {
		laserButton.sprite = buttonPressed;
		yield return new WaitForSeconds(.15f);
		laserButton.sprite = buttonUnPressed;
	}
}
