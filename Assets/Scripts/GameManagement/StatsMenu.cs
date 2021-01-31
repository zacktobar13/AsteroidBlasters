using UnityEngine;
using System.Collections;

public class StatsMenu : MonoBehaviour {

	MainMenu mainMenu;
	public GameObject mainMenuGameObject;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;

	void OnEnable () 
	{
		foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid")) {
			Destroy(asteroid);
		}
		foreach (GameObject shield in GameObject.FindGameObjectsWithTag("Shield")) {
			Destroy(shield);
		}
		foreach (GameObject nuke in GameObject.FindGameObjectsWithTag("Nuke")) {
			Destroy(nuke);
		}
		foreach (GameObject nukeDrop in GameObject.FindGameObjectsWithTag("NukeDrop")) {
			Destroy(nukeDrop);
		}
	}

	private void Start()
	{
		mainMenu = mainMenuGameObject.GetComponent<MainMenu>();
	}

	void Update () 
	{
		// Binds to back button on android.
        if(Input.GetKeyDown(KeyCode.Escape)) 
		{
			ShowMainMenu();
		}
	}

	public void RestartGame()
	{
		gameObject.SetActive(false);
		mainMenu.StartGame();
	}

	public void ShowMainMenu()
	{
		mainMenuGameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
