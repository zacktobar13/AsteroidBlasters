using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public GameObject[] mainMenuText, settingsMenuText;
	Image settingsButtonImage; 
	public Image soundToggleImage;
	public Sprite settingsPressed, settingsUnpressed, soundOn, soundOff;
	SoundManager soundManager;
	GeneralSounds generalSounds;
	bool settingsOn = false;
	float lastSettingsTouch;
	float settingsButtonCD = .3f;
	bool soundEnabled = true;

	void OnEnable() {
		settingsButtonImage = GetComponent<Image>();
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		generalSounds = GetComponent<GeneralSounds>();
	}
	
	void Update () {

		foreach(Touch touch in Input.touches) {
			if(touch.phase == TouchPhase.Ended) {
				if(OnSettingsButton(touch.position) && Time.time >= lastSettingsTouch + settingsButtonCD) {
					ToggleSettingsMenu();
				}
			}
			if (touch.phase == TouchPhase.Ended) {
				if (OnSoundToggler(touch.position)) {
					ToggleSound();
				} else if (OnEraseHighScore(touch.position)) {
					// TODO
				}
			}
		}	
	}	
	
		void ToggleSettingsMenu() {
			settingsOn = !settingsOn;
			lastSettingsTouch = Time.time;

			if(settingsOn) {
				settingsButtonImage.sprite = settingsPressed;
				soundManager.PlaySound(generalSounds.Sounds[0], .15f);
				foreach (GameObject text in mainMenuText) {
					text.SetActive(false);
				}

				foreach(GameObject text in settingsMenuText) {
					text.SetActive(true);
				}
			}
			
			else if(!settingsOn){
				settingsButtonImage.sprite = settingsUnpressed;
				soundManager.PlaySound(generalSounds.Sounds[1], .15f);
				if(MainMenu.activeGamePlaying == false) {
					foreach (GameObject text in mainMenuText) {
						text.SetActive(true);
					}
				}

				foreach(GameObject text in settingsMenuText) {
					text.SetActive(false);
				}
			}	
		}

		bool OnSettingsButton(Vector2 touchPos) {
			if (touchPos.x < Screen.width * .15 && touchPos.y > Screen.height * .5) {
				return true;
			}
			return false;
		}	

		bool OnSoundToggler(Vector2 touchPos) {
			if (touchPos.x > Screen.width * .72 &&  touchPos.x < Screen.width * .86 && 
				touchPos.y > Screen.height * .37 && touchPos.y < Screen.height * .57) {
				return true;
			}
			return false;
		}

		bool OnEraseHighScore(Vector2 touchPosition) {
			return true;// TODO
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


