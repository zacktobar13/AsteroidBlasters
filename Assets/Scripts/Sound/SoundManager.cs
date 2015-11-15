using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	AudioSource audioSources;
	bool soundEnabled;
	public GameObject Music;
	
	void Start () {
		audioSources = GetComponent<AudioSource>();
		soundEnabled = true;
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
