using UnityEngine;
using System.Collections;

public class LaserSound : MonoBehaviour {

	public AudioClip[] laserSounds;
	public float laserVolume;
	AudioSource audioSource;

	void Start() {                  //Sound played at start because this is attached to asteroid pieces.
		audioSource = GetComponent<AudioSource>();
		PlayLaserSound();
	}

	void PlayLaserSound() {
		if (laserSounds.Length != 0) {
            AudioClip laserSound = laserSounds[Random.Range(0, laserSounds.Length)];
            audioSource.volume = laserVolume;
            audioSource.PlayOneShot(laserSound);
        }
	}
}
