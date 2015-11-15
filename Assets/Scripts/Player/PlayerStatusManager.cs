using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour {

	public MainMenu mainMenu;
	public GameObject asteroidSpawner, playerPieces, laserButton;
	GameObject ScoreManager;

	void Start() {
		ScoreManager = GameObject.FindWithTag("ScoreManager");
	}
	// Use this for initialization
	public void GetRekt() {
		Destroy(Instantiate(playerPieces,transform.position, transform.rotation), 1.3f);
		mainMenu.enabled = true;
		asteroidSpawner.SetActive(false);
		laserButton.SetActive(false);
		gameObject.SetActive(false);
		ScoreManager.SendMessage("EndOfRound");
	}
}
