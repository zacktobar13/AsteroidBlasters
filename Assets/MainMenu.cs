using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject player;
	public GameObject asteroidSpawner;
	public GameObject[] menuText;

	// Use this for initialization
	void OnEnable () {
		foreach (GameObject text in menuText) {
			text.SetActive(true);
		}
		foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid")) {
			asteroid.SendMessage("GetRekt");
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				if (OnStartButton(touch.position)) {
					player.SetActive(true);
					asteroidSpawner.SetActive(true);
					foreach (GameObject text in menuText) {
						text.SetActive(false);
					}
					this.enabled = false;
				} // ADD OTHER BUTTONS HERE
			}
		}
	}

	bool OnStartButton(Vector2 touchPos) {
		if (touchPos.x > Screen.width * .4 && touchPos.x < Screen.width * .6 && 
			touchPos.y > Screen.height * .35 && touchPos.y < Screen.height * .55) {
			return true;
		}
		return false;
	}
}
