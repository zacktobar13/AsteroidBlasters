using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {

	public GameObject[] settingsMenuText;
	public GameObject soundManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches) { 
			if (touch.phase == TouchPhase.Began) {
				if (OnMusicToggler(touch.position)) {
					// TODO
				} else if (OnEraseHighScore(touch.position)) {
					// TODO
				}
			}
		}
	}

	bool OnMusicToggler(Vector2 touchPosition) {
		// TODO
	}

	bool OnEraseHighScore(Vector2 touchPosition) {
		// TODO
	}
}
