using UnityEngine;
using System.Collections;

public class GeneralSounds : MonoBehaviour {

	public AudioClip[] Sounds;
	SoundManager soundManager;
	public float volume;

	void Start() {
		soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
		AudioClip sound = Sounds[Random.Range(0, Sounds.Length)];

		if (volume != 0) {
			soundManager.PlaySound(sound, volume);
		} else {
			soundManager.PlaySound(sound);
		}
	}
}
