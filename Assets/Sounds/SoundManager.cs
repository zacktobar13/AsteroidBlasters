using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	AudioSource audioSources;

	
	void Start () {
		audioSources = GetComponent<AudioSource>();
	}
	
	public void PlaySound (AudioClip sound, float volume = -1f) {
		if (volume != -1f) {
			audioSources.volume = volume;
		}
		audioSources.PlayOneShot(sound);
	}
}
