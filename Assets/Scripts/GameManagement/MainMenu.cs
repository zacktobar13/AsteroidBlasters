using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject player, asteroidSpawner, laserButton, settingsButton, settingsButtonPressed;
	public GameObject[] menuText;
	public static bool activeGamePlaying = false;

	bool settingsOn = false;
	float lastSettingsTouch;

	// Use this for initialization
	void OnEnable () {

		foreach (GameObject text in menuText) {
			text.SetActive(true);
		}
		foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid")) {
			Destroy(asteroid);
		}
	}
	
	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				if (OnStartButton(touch.position) && !settingsOn) {
					StartGame();
				}
			} 
		}	
	}


		bool OnStartButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .4 && touchPos.x < Screen.width * .6 && 
			touchPos.y > Screen.height * .35 && touchPos.y < Screen.height * .55) {
			return true;
		}
		return false;
	}

	void StartGame() {
		activeGamePlaying = true;
		player.SetActive(true);
		laserButton.SetActive(true);
		asteroidSpawner.SetActive(true);
		foreach (GameObject text in menuText) {
			text.SetActive(false);
		}
			this.enabled = false;
	}	
}