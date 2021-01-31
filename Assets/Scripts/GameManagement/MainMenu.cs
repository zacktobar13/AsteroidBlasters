using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
	public GameObject player;
	public GameObject gameplayUI;
	public GameObject asteroidSpawner;
	public GameObject[] menuText, statMenuText;
	public Sprite settingsButtonPressed;
	public static bool activeGamePlaying = false;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;
	public GameObject settingsMenu;
	public bool canTouch = true;

	void OnEnable () 
	{
		ClearGameplayObjects();
		MainMenuShowing(true);
	}
	
	void Update () 
	{
		// This works for back button on mobile.
		if (Input.GetKeyDown(KeyCode.Escape)) {
			CloseApplication();
		}
	}

	public void StartGame() 
	{
		player.SetActive(true);
		asteroidSpawner.SetActive(true);
		gameplayUI.SetActive(true);
		gameObject.SetActive(false);
	}

	public void EnableSettingsMenu() 
	{
		MainMenuShowing(false);
		settingsMenu.SetActive(true);
	}

	public void MainMenuShowing(bool toggle) 
	{
		gameObject.SetActive(toggle);
	}

	public void CloseApplication()
	{
		Application.Quit();
	}

	void ClearGameplayObjects()
	{
		foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid"))
		{
			Destroy(asteroid);
		}
		foreach (GameObject shield in GameObject.FindGameObjectsWithTag("Shield"))
		{
			Destroy(shield);
		}
		foreach (GameObject nuke in GameObject.FindGameObjectsWithTag("Nuke"))
		{
			Destroy(nuke);
		}
		foreach (GameObject nukeDrop in GameObject.FindGameObjectsWithTag("NukeDrop"))
		{
			Destroy(nukeDrop);
		}
	}
}