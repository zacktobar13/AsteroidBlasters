using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour {

	public MainMenu mainMenu;
	public GameObject[] activeObjects, statsMenu;
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

	public void GetRekt() {
		if(!hasShield) {
			Destroy(Instantiate(playerPieces, transform.position, transform.rotation), 1.3f);
			miscStatManager.CalculateAllStats();

			foreach(GameObject obj in statsMenu) {
				obj.SetActive(true);
			}
			//mainMenu.enabled = true;
			playerMovement.canMove = false;
			shieldText.SetActive(false);
			fiftyPointsText.SetActive(false);
			nukeText.SetActive(false);
			foreach (GameObject obj in activeObjects) {
				obj.SetActive(false);
			}
				ScoreManager.SendMessage("EndOfRound");
				this.gameObject.SetActive(false);
		} else {
			DeActivateShield();
		}	
	}

	void FixedUpdate() {
		miscStatManager.distanceTraveled += Time.deltaTime;
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
