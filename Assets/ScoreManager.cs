using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	int currentScore;

	/* This is pulled from a file */
	int highestScore;

	public Text scoreTextUI;

	void Start () {
		currentScore = 0;
		highestScore = PullScoreFromFile();
		scoreTextUI.text = ScoreTextUI();
	}

	public void AddPoints(int amount) {
		currentScore += amount;
		scoreTextUI.text = ScoreTextUI();
	}

	public void EndOfRound() {
		if (currentScore > highestScore) {
			highestScore = currentScore;
		}
		currentScore = 0;
		scoreTextUI.text = ScoreTextUI();
	}

	int PullScoreFromFile() {
		string filePath = Application.persistentDataPath + "/score.txt";
		if (File.Exists(filePath) == false) {
			string[] temp = {""+currentScore};
			File.WriteAllLines(filePath, temp);


			return 0;
		} else {
			StreamReader reader = new StreamReader(filePath);
			string line = reader.ReadLine();
			reader.Close();
			return int.Parse(line);
		}
	}

	void OnApplicationQuit() {
		string filePath = Application.persistentDataPath + "/score.txt";
		Debug.Log(Application.persistentDataPath);
		string[] temp = {""+highestScore};
		File.WriteAllLines(filePath, temp);
	}

	string ScoreTextUI() {
		return "High Score: " + highestScore + "   Current Score: " + currentScore;
	}
}
