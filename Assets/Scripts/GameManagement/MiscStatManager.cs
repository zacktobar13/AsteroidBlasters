using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MiscStatManager : MonoBehaviour {

	[HideInInspector]
	public int shieldsCollected, nukesCollected;
	[HideInInspector]
	public float lasersFired, asteroidsDestroyed, laserAccuracy, distanceTraveled;

	public Text distanceTraveledText, lasersFiredText, asteroidsDestroyedText, laserAccuracyText, shieldsCollectedText, nukesCollectedText;
	public Text bestDistanceTraveledText, bestLasersFiredText, bestAsteroidsDestroyedText, bestLaserAccuracyText, bestShieldsCollectedText, bestNukesCollectedText;

	[HideInInspector]
	public int highestShieldsCollected, highestNukesCollected;
	[HideInInspector]
	public float highestLasersFired, highestAsteroidsDestroyed, highestLaserAccuracy, highestDistanceTraveled;

	bool newHighScore;

	public void CalculateAllStats() {
		highestShieldsCollected = PlayerPrefs.GetInt("highestShieldsCollected");
		highestNukesCollected = PlayerPrefs.GetInt("highestNukesCollected");
		highestLasersFired = PlayerPrefs.GetFloat("highestLasersFired");
		highestAsteroidsDestroyed = PlayerPrefs.GetFloat("highestAsteroidsDestroyed");
		highestDistanceTraveled = PlayerPrefs.GetFloat("highestDistanceTraveled");
		highestLaserAccuracy = PlayerPrefs.GetFloat("highestLaserAccuracy");

		laserAccuracy = asteroidsDestroyed / lasersFired;
		if (laserAccuracy > 1f) {
			laserAccuracy = 1f;
		}

		string accuracyString = string.Format("{0:0.0%}", laserAccuracy);
		string bestAccuracyString = string.Format("{0:0.0%}", highestLaserAccuracy);
		string distanceString = string.Format("{0:0.00}", distanceTraveled);
		string bestDistanceString = string.Format("{0:0.00}", highestDistanceTraveled);

		if(asteroidsDestroyed == 0) {
			accuracyString = "0%";
		}

		laserAccuracyText.text = accuracyString;
		distanceTraveledText.text = distanceString + " AU";
		lasersFiredText.text = lasersFired.ToString();
		asteroidsDestroyedText.text = asteroidsDestroyed.ToString();
		shieldsCollectedText.text = shieldsCollected.ToString();
		nukesCollectedText.text = nukesCollected.ToString();

		//Highest Scores
		bestLaserAccuracyText.text = bestAccuracyString;
		bestDistanceTraveledText.text = bestDistanceString + " AU";
		bestLasersFiredText.text = highestLasersFired.ToString();
		bestAsteroidsDestroyedText.text = highestAsteroidsDestroyed.ToString();
		bestShieldsCollectedText.text = highestShieldsCollected.ToString();
		bestNukesCollectedText.text = highestNukesCollected.ToString();

		if (newHighScore) {
			NewBestStats();
		}
	}

	void NewBestStats() {
		PlayerPrefs.SetInt("highestShieldsCollected", shieldsCollected);
		PlayerPrefs.SetInt("highestNukesCollected", nukesCollected);
		PlayerPrefs.SetFloat("highestLasersFired", lasersFired);
		PlayerPrefs.SetFloat("highestAsteroidsDestroyed", asteroidsDestroyed);
		PlayerPrefs.SetFloat("highestDistanceTraveled", distanceTraveled);
		PlayerPrefs.SetFloat("highestLaserAccuracy", laserAccuracy);
	}

	public void GotHighScore(bool gotHighScore) {
		newHighScore = gotHighScore;
	}
}
