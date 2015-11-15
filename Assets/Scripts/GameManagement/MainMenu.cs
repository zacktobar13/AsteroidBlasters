using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject player, asteroidSpawner, laserButton;
	public GameObject[] menuText;
	SettingsMenu settingsMenu;

	// Use this for initialization
	void OnEnable () {
		settingsMenu = GetComponent<SettingsMenu>();
		foreach (GameObject text in menuText) {
			text.SetActive(true);
		}
		foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid")) {
			Destroy(asteroid);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				if (OnStartButton(touch.position)) {
					player.SetActive(true);
					laserButton.SetActive(true);
					asteroidSpawner.SetActive(true);
					foreach (GameObject text in menuText) {
						text.SetActive(false);
					}
					this.enabled = false;
				} else if (OnSettingsButton(touch.position)) {
					settingsMenu.enabled = true;
					foreach (GameObject text in menuText) {
						text.SetActive(false);
					}
					this.enabled = false;
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

	bool OnSettingsButton(Vector2 touchPos) {
		if (touchPos.x < Screen.width * .20 && touchPos.y > Screen.width * .8) {
			return true;
		}
		return false;
	}
}
