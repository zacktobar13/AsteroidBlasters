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
	PlayerMovement playerMovement;
	public GameObject shieldText;

	void Start() {
		ScoreManager = GameObject.FindWithTag("ScoreManager");
		generalSounds = gameObject.GetComponent<GeneralSounds>();
		playerMovement = gameObject.GetComponent<PlayerMovement>();
	}

	public void GetRekt() {
		if(!hasShield) {
			Destroy(Instantiate(playerPieces, transform.position, transform.rotation), 1.3f);
			mainMenu.enabled = true;
			playerMovement.canMove = false;
			shieldText.SetActive(false);
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
		StartCoroutine("ShowShieldText");
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

	IEnumerator ShowShieldText() {
		shieldText.SetActive(true);
		yield return new WaitForSeconds(2f);
		shieldText.SetActive(false);
	}
}
