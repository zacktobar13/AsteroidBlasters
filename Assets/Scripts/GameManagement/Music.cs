using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	SoundManager soundManager;
	public AudioClip music;

	void Start () {
		soundManager = GetComponent<SoundManager>();
		soundManager.PlaySound(music);
	}
}
