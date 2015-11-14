using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	int currentScore;
	string filePath;

	/* This is pulled from a file */
	int highestScore;

	public Text scoreTextUI;

	void Start () {
		currentScore = 0;
		filePath = Application.persistentDataPath + "/score.txt";
		highestScore = PullScoreFromFile();
		scoreTextUI.text = ScoreTextUI();
	}

	public void AddPoints(int amount) {
		currentScore += amount;
		if (currentScore > highestScore) {
			highestScore = currentScore;
		}
		scoreTextUI.text = ScoreTextUI();
	}

	public void EndOfRound() {
		if (currentScore > highestScore) {
			highestScore = currentScore;
		}
		currentScore = 0;
		scoreTextUI.text = ScoreTextUI();
		string[] temp = {""+highestScore};
		File.WriteAllLines(filePath, temp);
	}

	int PullScoreFromFile() {
		if (File.Exists(filePath) == false) {
			string[] temp = {""+currentScore};
			File.WriteAllLines(filePath, temp);
			return 0;
		} else {
			StreamReader reader = new StreamReader(filePath);
			string line = reader.ReadLine();
			reader.Close();
			scoreTextUI.text = "" + int.Parse(line);
			return int.Parse(line);
		}
	}

	string ScoreTextUI() {
		return "High Score: " + highestScore + "   Current Score: " + currentScore;
	}
}
