using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	int currentScore, previousRoundsScore;
	string filePath;
	bool firstHighScore = true;

	int highestScore;

	public Text scoreTextUI, newHighScore;

	void Start () {
		currentScore = 0;
		filePath = Application.persistentDataPath + "/score.txt";
		highestScore = PullScoreFromFile();
		scoreTextUI.text = "High Score: " + highestScore;
	}

	public void AddPoints(int amount) {
		currentScore += amount;
		if (currentScore > highestScore && firstHighScore) {
			StartCoroutine("ShowHighScoreText", 2.5f);
			firstHighScore = false;
		}
		scoreTextUI.text = CurrentScore();
	}

	public void EndOfRound() {
		if (currentScore > highestScore) {
			highestScore = currentScore;
		}
		firstHighScore = true;
		previousRoundsScore = currentScore;
		currentScore = 0;
		scoreTextUI.text = MainMenuScore();
		string[] temp = {""+highestScore};
		File.WriteAllLines(filePath, temp);
	}

	public void resetHighScore() {
		string[] temp = {"0"};
		File.WriteAllLines(filePath, temp);
		highestScore = 0;
		previousRoundsScore = 0;
		scoreTextUI.text = MainMenuScore();
	}

	IEnumerator ShowHighScoreText(int seconds) {
		newHighScore.text = "NEW HIGH SCORE!";
		yield return new WaitForSeconds(seconds);
		newHighScore.text = "";
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

	string CurrentScore() {
		return "Current Score: " + currentScore;
	}
	string MainMenuScore() {
		return "High Score: " + highestScore + "    Last Score: " + previousRoundsScore; 
	}
}
