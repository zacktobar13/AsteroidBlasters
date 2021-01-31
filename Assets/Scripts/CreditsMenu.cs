using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
	public GameObject settingsMenu;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ShowSettingsMenu();
		}
	}

	public void ShowSettingsMenu()
	{
		settingsMenu.SetActive(true);
		gameObject.SetActive(false);
	}
}
