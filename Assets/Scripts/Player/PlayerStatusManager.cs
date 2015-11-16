using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour {

	public MainMenu mainMenu;
	public GameObject asteroidSpawner, playerPieces, playerExplosion, laserButton;
	GameObject ScoreManager;

	void Start() {
		ScoreManager = GameObject.FindWithTag("ScoreManager");
	}
	// Use this for initialization
	public void GetRekt() {
		Destroy(Instantiate(playerPieces,transform.position, transform.rotation), 1.3f);
		Destroy(Instantiate(playerExplosion,transform.position, transform.rotation), .5f);
		mainMenu.enabled = true;
		asteroidSpawner.SetActive(false);
		laserButton.SetActive(false);
		gameObject.SetActive(false);
		ScoreManager.SendMessage("EndOfRound");
	}
}
