using UnityEngine;
using System.Collections;

public class StatsMenu : MonoBehaviour {

	MainMenu mainMenu;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;

	void OnEnable () {
		mainMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();

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

	void Update () {
        foreach(Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                if (OnRetry(touch.position)) {
                    mainMenu.StartGame();
                } else if (OnMenu(touch.position)) {
                	soundManager.PlaySound(generalSounds.Sounds[0]);
                    mainMenu.ToggleMainMenu();
            	}
        	} 
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            mainMenu.ToggleMainMenu();
        }
	}
	
    bool OnRetry(Vector2 touchPos) {
        if (touchPos.x < Screen.width * .49 && touchPos.x > Screen.width * .23
             && touchPos.y < Screen.height * .18 && touchPos.y > Screen.height * .01) {
                return true;
        }
        return false;
    }

    bool OnMenu(Vector2 touchPos) {
        if (touchPos.x > Screen.width * .55 && touchPos.x < Screen.width * .76
             && touchPos.y < Screen.height * .18 && touchPos.y > Screen.height * .01) {
                return true;
        }
        return false;
    }  
}
