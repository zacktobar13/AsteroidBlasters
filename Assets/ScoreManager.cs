using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

public class ScoreManager : MonoBehaviour {

	int currentScore;

	/* This is pulled from a file */
	int highestScore;

	void Start () {
		currentScore = 0;
		highestScore = PullScoreFromFile();
		Debug.Log("Highest Score: " + highestScore);
	}

	public void AddPoints(int amount) {
		currentScore += amount;
	}

	public void EndOfRound() {
		if (currentScore > highestScore) {
			highestScore = currentScore;
		}
		currentScore = 0;
	}

	int PullScoreFromFile() {
		string filePath = Application.dataPath + "/score.txt";
		if (File.Exists(filePath) == false) {
			string[] temp = {""+currentScore};
			File.WriteAllLines(filePath, temp);
			Debug.Log(filePath);
			return 0;
		} else {
			StreamReader reader = new StreamReader(filePath);
			Debug.Log(filePath);
			string line = reader.ReadLine();
			return int.Parse(line);
		}
	}

	void OnApplicationQuit() {
		string filePath = Application.dataPath + "/score.txt";
		string[] temp = {""+highestScore};
		File.WriteAllLines(filePath, temp);
	}
}
