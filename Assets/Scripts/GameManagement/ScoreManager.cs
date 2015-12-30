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
	public GameObject scorePostedText, scoreFailedText;
	public MiscStatManager miscStatManager;

	int highestScore;

	public Text scoreTextUI, newHighScore;

	void Start () {
		generalSounds = GetComponent<GeneralSounds>();
		currentScore = 0;
		highestScore = PlayerPrefs.GetInt("HighScore");
		scoreTextUI.text = "High Score: " + highestScore;
	}

	public void AddPoints(int amount) {
		currentScore += amount;
		miscStatManager.distanceTraveled += 1;
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
		PlayerPrefs.SetInt("HighScore", highestScore);
	}

	IEnumerator ShowScorePosted() {
		scorePostedText.SetActive(true);
		yield return new WaitForSeconds(2f);
		scorePostedText.SetActive(false);
	}

	IEnumerator ShowScoreFailed() {
		scoreFailedText.SetActive(true);
		yield return new WaitForSeconds(2f);
		scoreFailedText.SetActive(false);
	}

	public void resetHighScore() {
		PlayerPrefs.SetInt("HighScore", 0);
		highestShieldsCollected = PlayerPrefs.SetInt("highestShieldsCollected", 0);
		highestNukesCollected = PlayerPrefs.SetInt("highestNukesCollected", 0);
		highestLasersFired = PlayerPrefs.SetFloat("highestLasersFired", 0f);
		highestAsteroidsDestroyed = PlayerPrefs.SetFloat("highestAsteroidsDestroyed", 0f);
		highestDistanceTraveled = PlayerPrefs.SetFloat("highestDistanceTraveled", 0f);
		highestLaserAccuracy = PlayerPrefs.SetFloat("highestLaserAccuracy", 0f);
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
	        		StartCoroutine("ShowScorePosted");
	        	} else {
	        		StartCoroutine("ShowScoreFailed");
	        	}
	    	});
		} else {
			StartCoroutine("ShowScoreFailed");
		}
	}
}
