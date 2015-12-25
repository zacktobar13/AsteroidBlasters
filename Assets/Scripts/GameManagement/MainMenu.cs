using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour {

	public GameObject[] startOfGameObjects;
	public GameObject[] menuText;
	public Image settingsButton;
	public Sprite settingsButtonPressed;
	public static bool activeGamePlaying = false;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;
	public SettingsMenu settingsMenu;
	string leaderboard = "CgkI9IT9xcoVEAIQAQ";
	public GameObject googlePlay;
	public GameObject leaderboardFailText, alreadyLoggedInText, logInFailedText, logInSuccessText;
	public bool canTouch = true;
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
			if(canTouch) {
				if (touch.phase == TouchPhase.Began) {
					if (OnStartButton(touch.position)) {
						StartGame();
					} else if (OnQuitButton(touch.position)) {
						Application.Quit();
					} else if (OnSettingsButton(touch.position)) {
						EnableSettingsMenu();
					} else if (OnLeaderboardButton(touch.position)) {
						if(PlayGamesPlatform.Instance.IsAuthenticated()) {
							PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboard);
						} else {
							soundManager.PlaySound(generalSounds.Sounds[1]);
							StartCoroutine("LeaderboardFail");
						}
					} else if (OnLogInButton(touch.position)) {
						if(!PlayGamesPlatform.Instance.IsAuthenticated()) {
							googlePlay.SendMessage("LogIn");
						} else {
							StartCoroutine("AlreadyLoggedIn");
						}
					}
				}
			}
		}	

		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	IEnumerator LeaderboardFail() {
		canTouch = false;
		foreach (GameObject text in menuText) {
			text.SetActive(false);
		}

		leaderboardFailText.SetActive(true);
		yield return new WaitForSeconds(2f);
		leaderboardFailText.SetActive(false);

		foreach (GameObject text in menuText) {
			text.SetActive(true);
		}
		canTouch = true;
	}

	IEnumerator AlreadyLoggedIn() {
		soundManager.PlaySound(generalSounds.Sounds[0]);
		canTouch = false;
		foreach (GameObject text in menuText) {
			text.SetActive(false);
		}

		alreadyLoggedInText.SetActive(true);
		yield return new WaitForSeconds(2f);
		alreadyLoggedInText.SetActive(false);

		foreach (GameObject text in menuText) {
			text.SetActive(true);
		}
		canTouch = true;
	}

	public void LogInSuccess() {
		StartCoroutine("SuccessfulLogIn");
	}

	IEnumerator SuccessfulLogIn() {
		logInSuccessText.SetActive(true);
		yield return new WaitForSeconds(2f);
		logInSuccessText.SetActive(false);
	}

	public void FailedLogIn() {
		StartCoroutine("LogInFailed");
	}

	IEnumerator LogInFailed() {
		canTouch = false;
		soundManager.PlaySound(generalSounds.Sounds[1]);
		foreach (GameObject text in menuText) {
			text.SetActive(false);
		}

		logInFailedText.SetActive(true);
		yield return new WaitForSeconds(2f);
		logInFailedText.SetActive(false);

		foreach (GameObject text in menuText) {
			text.SetActive(true);
		}
		canTouch = true;
	}

	bool OnStartButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .4 && touchPos.x < Screen.width * .6
			&& touchPos.y > Screen.height * .35 && touchPos.y < Screen.height * .55) {
				return true;
		}
		return false;
	}

	bool OnQuitButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .81
			&& touchPos.y > Screen.height * .77 && touchPos.y < Screen.height * .9) {
				soundManager.PlaySound(generalSounds.Sounds[0]);
				return true;
		}
		return false;
	}

	bool OnLeaderboardButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .29 && touchPos.x < Screen.width * .7
			&& touchPos.y > Screen.height * .23 && touchPos.y < Screen.height * .36) {
			return true;
		}
		return false;
	}

	bool OnLogInButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .34 && touchPos.x < Screen.width * .6 && touchPos.y < Screen.height * .12) {
			return true;
		}
		return false;
	}		

	bool OnSettingsButton(Vector2 touchPos) {
		if (touchPos.x < Screen.width * .15 && touchPos.y > Screen.height * .85) {
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