using UnityEngine;
using System.Collections;

public class PlayerExplosionSound : MonoBehaviour {

	public AudioClip[] explosionSounds;
	public float explosionVolume;
	AudioSource audioSource;

	void Start() {                  //Sound played at start because this is attached to player pieces.
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
