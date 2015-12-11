using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public GameObject[] settingsMenuText;
	public GameObject creditsMenu, backButton;
	public Image soundToggleImage;
	public Sprite settingsPressed, settingsUnpressed, soundOn, soundOff;
	SoundManager soundManager;
	GeneralSounds generalSounds;
	bool soundEnabled = true;
	bool creditsEnabled = false;
	public MainMenu mainMenu;

	void OnEnable() {
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		generalSounds = GetComponent<GeneralSounds>();
		foreach(GameObject text in settingsMenuText) {
			text.SetActive(true);
		}
	}
	
	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				if (OnSoundToggler(touch.position)) {
					ToggleSound();
				} else if (OnEraseHighScore(touch.position)) {
					// TO DO
				} else if (OnSettingsButton(touch.position)) {
					ToggleSettingsMenu();
				} else if (OnCreditsButton(touch.position)) {
					ShowCredits();
				}
			}
		}
	}
	
	void ToggleSettingsMenu() {
		soundManager.PlaySound(generalSounds.Sounds[0], .15f);
		foreach(GameObject text in settingsMenuText) {
			text.SetActive(false);
		}
		mainMenu.enabled = true;
		this.enabled = false;
	}

	bool OnSoundToggler(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .72 &&  touchPos.x < Screen.width * .86 && 
			touchPos.y > Screen.height * .37 && touchPos.y < Screen.height * .57) {
			return true;
		}
		return false;
	}

	bool OnEraseHighScore(Vector2 touchPosition) {
		return false; // TO DO
	}

	bool OnSettingsButton(Vector2 touchPos) {
		if (touchPos.x < Screen.width * .15 && touchPos.y > Screen.height * .5) {
			return true;
		}
		return false;
	}

	bool OnCreditsButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .8
			 && touchPos.y < Screen.height * .08) {
				return true;
		}
		return false;
	}

	void ShowCredits() {
		creditsEnabled = !creditsEnabled;

		if(creditsEnabled) {
			soundManager.PlaySound(generalSounds.Sounds[0], 1f);

			foreach(GameObject text in settingsMenuText) {
				text.SetActive(false);
			}
			backButton.SetActive(true);
			creditsMenu.SetActive(true);
		} else {
			soundManager.PlaySound(generalSounds.Sounds[0], 1f);

			foreach(GameObject text in settingsMenuText) {
				text.SetActive(true);
			}
			backButton.SetActive(false);
			creditsMenu.SetActive(false);
		}
	}

	void ToggleSound() {
		soundEnabled = !soundEnabled;

		if(soundEnabled == true) {
			soundManager.DisableSound();
			soundToggleImage.sprite = soundOff;
		} else {
			soundManager.EnableSound();
			soundToggleImage.sprite = soundOn;
		}
	}
		
}


