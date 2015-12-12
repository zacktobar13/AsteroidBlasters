using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour {

	public MainMenu mainMenu;
	public GameObject[] activeObjects;
	public GameObject playerPieces, shieldSprite;
	GameObject ScoreManager;
	public bool hasShield = false;
	public SoundManager soundManager;
	GeneralSounds generalSounds;

	void Start() {
		ScoreManager = GameObject.FindWithTag("ScoreManager");
		generalSounds = gameObject.GetComponent<GeneralSounds>();
	}

	public void GetRekt() {
		if(!hasShield) {
			Destroy(Instantiate(playerPieces, transform.position, transform.rotation), 1.3f);
			mainMenu.enabled = true;
			foreach (GameObject obj in activeObjects) {
				obj.SetActive(false);
			}
				ScoreManager.SendMessage("EndOfRound");
				this.gameObject.SetActive(false);
		} else {
			DeActivateShield();
		}	
	}

	public void ActivateShield() {
		hasShield = true;
		shieldSprite.SetActive(true);
		soundManager.PlaySound(generalSounds.Sounds[0]);
	}

	public void DeActivateShield() {
		hasShield = false;
		shieldSprite.SetActive(false);
		soundManager.PlaySound(generalSounds.Sounds[1]);
		soundManager.PlaySound(generalSounds.Sounds[2]);
	}
}
