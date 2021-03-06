using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour 
{

	public MainMenu mainMenu;
	public GameObject statsMenu;
	public GameObject[] activeObjects;
	public GameObject playerPieces, shieldSprite;
	GameObject ScoreManager;
	public bool hasShield = false;
	public SoundManager soundManager;
	GeneralSounds generalSounds;
	PlayerMovement playerMovement;
	public GameObject shieldText, fiftyPointsText, nukeText;
	public MiscStatManager miscStatManager;

	void Start() {
		ScoreManager = GameObject.FindWithTag("ScoreManager");
		generalSounds = gameObject.GetComponent<GeneralSounds>();
		playerMovement = gameObject.GetComponent<PlayerMovement>();
	}

	void OnEnable() {
		miscStatManager.distanceTraveled = 0f;
		miscStatManager.lasersFired = 0;
		miscStatManager.asteroidsDestroyed = 0f;
		miscStatManager.shieldsCollected = 0;
		miscStatManager.nukesCollected = 0;
		miscStatManager.laserAccuracy = 0f;
	}

	public void PlayerDeath() {
		if(!hasShield) 
		{
			Destroy(Instantiate(playerPieces, transform.position, transform.rotation), 1.3f);
			ScoreManager.SendMessage("EndOfRound");
			miscStatManager.CalculateAllStats();
		

		    statsMenu.SetActive(true);

			//mainMenu.enabled = true;
			playerMovement.canMove = false;
			shieldText.SetActive(false);
			fiftyPointsText.SetActive(false);
			nukeText.SetActive(false);
			foreach (GameObject obj in activeObjects) 
			{
				obj.SetActive(false);
			}
			this.gameObject.SetActive(false);
		} else {
			DeActivateShield();
		}	
	}

	void FixedUpdate() {
		miscStatManager.distanceTraveled += .2f;
	}

	public void ActivateShield() {
		if(!hasShield) {
			StartCoroutine("ShowShieldText");
		} else {
			StartCoroutine("ShowFiftyPointsText");
		}
		miscStatManager.shieldsCollected += 1;
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
		nukeText.SetActive(false);
		fiftyPointsText.SetActive(false);
		shieldText.SetActive(true);
		yield return new WaitForSeconds(2f);
		shieldText.SetActive(false);
	}

	IEnumerator ShowFiftyPointsText() {
		nukeText.SetActive(false);
		shieldText.SetActive(false);
		fiftyPointsText.SetActive(true);
		yield return new WaitForSeconds(2f);
		fiftyPointsText.SetActive(false);
	}
}
