using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject player, asteroidSpawner, laserButton, thrustButton, startButton, creditsButton, quitButton, settingsButton, settingsButtonPressed;
	public GameObject[] menuText;
	public static bool activeGamePlaying = false;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;

	bool settingsOn = false;
	float lastSettingsTouch;

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
			soundManager.PlaySound(generalSounds.Sounds[0], 1f);
			return true;
		}
		return false;
	}

	void StartGame() {
		activeGamePlaying = true;
		player.SetActive(true);
		startButton.SetActive(false);
		creditsButton.SetActive(false);
		quitButton.SetActive(false);
		thrustButton.SetActive(true);
		laserButton.SetActive(true);
		asteroidSpawner.SetActive(true);
		foreach (GameObject text in menuText) {
			text.SetActive(false);
		}
			this.enabled = false;
	}	
}