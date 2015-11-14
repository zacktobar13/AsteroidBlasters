using UnityEngine;
using System.Collections;

public class AsteroidSound : MonoBehaviour {

	public AudioClip[] explosionSounds;
	public float explosionVolume;
	AudioSource audioSource;

	void Start() {                  //Sound played at start because this is attached to asteroid pieces.
		audioSource = GetComponent<AudioSource>();
		PlayExplosionSound();
	}

	void PlayExplosionSound() {
		if (explosionSounds.Length != 0) {
            AudioClip explosionSound = explosionSounds[Random.Range(0, explosionSounds.Length)];
            audioSource.volume = explosionVolume;
            audioSource.PlayOneShot(explosionSound);
        }
	}
}
