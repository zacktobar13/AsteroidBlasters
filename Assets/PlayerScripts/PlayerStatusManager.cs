using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour {

	public MainMenu mainMenu;
	public GameObject asteroidSpawner;
	GameObject ScoreManager;

	void Start() {
		ScoreManager = GameObject.FindWithTag("ScoreManager");
	}
	// Use this for initialization
	public void GetRekt() {
		mainMenu.enabled = true;
		asteroidSpawner.SetActive(false);
		gameObject.SetActive(false);
		ScoreManager.SendMessage("EndOfRound");
	}
}
