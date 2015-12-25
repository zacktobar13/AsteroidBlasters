using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class ScoreManager : MonoBehaviour {

	int currentScore, previousRoundsScore;
	string filePath;
	string leaderboard = "CgkI9IT9xcoVEAIQAQ";
	bool firstHighScore = true;
	GeneralSounds generalSounds;
	public SoundManager soundManager;

	int highestScore;

	public Text scoreTextUI, newHighScore;

	void Start () {
		generalSounds = GetComponent<GeneralSounds>();
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

	private void EndOfRound() {
		if (currentScore > highestScore) {
			highestScore = currentScore;
			UpdateLeaderboard(highestScore);
		}
		firstHighScore = true;
		previousRoundsScore = currentScore;
		scoreTextUI.text = MainMenuScore();
		currentScore = 0;
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
		soundManager.PlaySound(generalSounds.Sounds[0]);
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

	void UpdateLeaderboard(int score) {
		if(PlayGamesPlatform.Instance.IsAuthenticated()) {
			Social.ReportScore(score, leaderboard, (bool success) => {
	        	if(success) {
	        		PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboard);
	        	} else {
	        		//Whomp whomp.
	        	}
	    	});
		}
	}
}
