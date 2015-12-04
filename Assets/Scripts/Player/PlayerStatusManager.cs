using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour {

	public MainMenu mainMenu;
	public GameObject[] activeObjects;
	public GameObject playerPieces;
	GameObject ScoreManager;

	void Start() {
		ScoreManager = GameObject.FindWithTag("ScoreManager");
	}

	public void GetRekt() {
		Destroy(Instantiate(playerPieces, transform.position, transform.rotation), 1.3f);
		mainMenu.enabled = true;
		foreach (GameObject obj in activeObjects) {
			obj.SetActive(false);
		}
		ScoreManager.SendMessage("EndOfRound");
		this.gameObject.SetActive(false);
	}
}
