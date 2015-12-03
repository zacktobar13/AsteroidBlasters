using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour {

	public MainMenu mainMenu;
	public GameObject asteroidSpawner, playerPieces, laserButton, thrustButton, startButton, creditsButton, quitButton;
	GameObject ScoreManager;

	void Start() {
		ScoreManager = GameObject.FindWithTag("ScoreManager");
	}

	public void GetRekt() {
		Destroy(Instantiate(playerPieces,transform.position, transform.rotation), 1.3f);
		mainMenu.enabled = true;
		asteroidSpawner.SetActive(false);
		laserButton.SetActive(false);
		startButton.SetActive(true);
		creditsButton.SetActive(true);
		quitButton.SetActive(true);
		thrustButton.SetActive(false);
		gameObject.SetActive(false);
		MainMenu.activeGamePlaying = false;
		ScoreManager.SendMessage("EndOfRound");
	}
}
