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

	void Start() {
		highestShieldsCollected = PlayerPrefs.GetInt("highestShieldsCollected");
		highestNukesCollected = PlayerPrefs.GetInt("highestNukesCollected");
		highestLasersFired = PlayerPrefs.GetFloat("highestLasersFired");
		highestAsteroidsDestroyed = PlayerPrefs.GetFloat("highestAsteroidsDestroyed");
		highestDistanceTraveled = PlayerPrefs.GetFloat("highestDistanceTraveled");
		highestLaserAccuracy = PlayerPrefs.GetFloat("highestLaserAccuracy");
	}

	public void CalculateAllStats() {
		laserAccuracy = asteroidsDestroyed / lasersFired;
		string accuracyString = string.Format("{0:0.0%}", laserAccuracy);
		string bestAccuracyString = string.Format("{0:0.0%}", highestLaserAccuracy);
		string distanceString = string.Format("{0:0.00}", distanceTraveled);
		string bestDistanceString = string.Format("{0:0.00}", highestDistanceTraveled);

		if(asteroidsDestroyed == 0) {
			accuracyString = "0%";
		}

		CompareCurrentStatsToHighest();

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
	}

	void CompareCurrentStatsToHighest() {
		if (shieldsCollected > highestShieldsCollected) {
			highestNukesCollected = shieldsCollected;
			PlayerPrefs.SetFloat("highestShieldsCollected", shieldsCollected);
		}
		if (nukesCollected > highestNukesCollected) {
			highestNukesCollected = nukesCollected;
			PlayerPrefs.SetInt("highestNukesCollected", nukesCollected);
		}
		if (lasersFired > highestLasersFired) {
			highestLasersFired = lasersFired;
			PlayerPrefs.SetFloat("highestLasersFired", lasersFired);
		}
		if (asteroidsDestroyed > highestAsteroidsDestroyed) {
			highestAsteroidsDestroyed = asteroidsDestroyed;
			PlayerPrefs.SetFloat("highestAsteroidsDestroyed", asteroidsDestroyed);
		}
		if (distanceTraveled > highestDistanceTraveled) {
			highestDistanceTraveled = distanceTraveled;
			PlayerPrefs.SetFloat("highestDistanceTraveled", distanceTraveled);
		}
		if (laserAccuracy > highestLaserAccuracy) {
			highestLaserAccuracy = laserAccuracy;
			PlayerPrefs.SetFloat("highestLaserAccuracy", laserAccuracy);
		}
	}
}
