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
        filePath = Application.persistentDataPath + "/sound.txt";
        if (File.Exists(filePath)) {
        	soundEnabled = PullSoundFromFile();
        	if (soundEnabled) {
        		EnableSound();
        	} else {
        		DisableSound();
        	}
        } else {
        	WriteSoundToFile(true);
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

	bool PullSoundFromFile() {
		StreamReader reader = new StreamReader(filePath);
		string line = reader.ReadLine();
		reader.Close();
		return line == "True";
	}

	void WriteSoundToFile(bool toggler) {
        string[] temp = {""+toggler};
        File.WriteAllLines(filePath, temp);
    }
}
