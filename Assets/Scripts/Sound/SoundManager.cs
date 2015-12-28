using UnityEngine;
using System.Collections;
using System.IO;

public class SoundManager : MonoBehaviour {

	AudioSource audioSources;
	bool soundEnabled;
	public GameObject Music;
	string filePath;
	
	void Start () {
		audioSources = GetComponent<AudioSource>();
        string sound = PlayerPrefs.GetString("Sound");
        if (sound == "") {
        	PlayerPrefs.SetString("Sound", "True");
        } else {
        	if (sound == "True") {
        		EnableSound();
    		} else {
    			DisableSound();
    		}
        }
	}
	
	public void PlaySound (AudioClip sound, float volume = -1f) {
		if (soundEnabled == false) {
			return;
		}
		if (volume != -1f) {
			audioSources.volume = volume;
		}
		audioSources.PlayOneShot(sound);
	}

	public void EnableSound() {
		soundEnabled = true;
		Music.SetActive(true);
	}

	public void DisableSound() {
		soundEnabled = false;
		Music.SetActive(false);
	}
}
