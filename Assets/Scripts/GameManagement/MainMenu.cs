using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject[] startOfGameObjects;
	public GameObject[] menuText;
	public Image settingsButton;
	public Sprite settingsButtonPressed;
	public static bool activeGamePlaying = false;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;
	public SettingsMenu settingsMenu;

	float lastSettingsTouch;

	void OnEnable () {
		foreach (GameObject text in menuText) {
			text.SetActive(true);
		}
		foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid")) {
			Destroy(asteroid);
		}
		foreach (GameObject shield in GameObject.FindGameObjectsWithTag("Shield")) {
			Destroy(shield);
		}
	}
	
	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				if (OnStartButton(touch.position)) {
					StartGame();
				} else if (OnQuitButton(touch.position)) {
					Application.Quit();
				} else if (OnSettingsButton(touch.position)) {
					EnableSettingsMenu();
				}
			}
		}	
	}

	bool OnStartButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .4 && touchPos.x < Screen.width * .6
			&& touchPos.y > Screen.height * .35 && touchPos.y < Screen.height * .55) {
				soundManager.PlaySound(generalSounds.Sounds[0]);
				return true;
		}
		return false;
	}

	bool OnQuitButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .4 && touchPos.x < Screen.width * .6
			&& touchPos.y > Screen.height * .15 && touchPos.y < Screen.height * .35) {
				soundManager.PlaySound(generalSounds.Sounds[0]);
				return true;
		}
		return false;
	}

	bool OnSettingsButton(Vector2 touchPos) {
		if (touchPos.x < Screen.width * .15 && touchPos.y > Screen.height * .5) {
			return true;
		}
		return false;
	}	

	void StartGame() {
		foreach (GameObject startOfGameObject in startOfGameObjects) {
			startOfGameObject.SetActive(true);
		}
		foreach (GameObject text in menuText) {
			text.SetActive(false);
		}
		this.enabled = false;
	}

	void EnableSettingsMenu() {
		foreach (GameObject text in menuText) {
			text.SetActive(false);
		}
		settingsButton.sprite = settingsButtonPressed;
		settingsMenu.enabled = true;
		this.enabled = false;
	}
}