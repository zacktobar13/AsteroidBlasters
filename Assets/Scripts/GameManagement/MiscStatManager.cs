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

	[HideInInspector]
	public int highestShieldsCollected, highestNukesCollected;
	[HideInInspector]
	public float highestLasersFired, highestAsteroidsDestroyed, highestLaserAccuracy, highestDistanceTraveled;

	/** Everything has a max except for laser accuracy because that could
	  * easily just be 100% by firing one time and then dying. */
	void Start() {
		highestShieldsCollected = PlayerPrefs.GetInt("highestShieldsCollected");
		highestNukesCollected = PlayerPrefs.GetInt("highestNukesCollected");
		highestLasersFired = PlayerPrefs.GetFloat("highestLasersFired");
		highestAsteroidsDestroyed = PlayerPrefs.GetFloat("highestAsteroidsDestroyed");
		highestDistanceTraveled = PlayerPrefs.GetFloat("highestDistanceTraveled");
	}

	public void CalculateAllStats() {
		laserAccuracy = asteroidsDestroyed / lasersFired;
		string accuracyString = string.Format("{0:0.0%}", laserAccuracy);
		string distanceString = string.Format("{0:0.00}", distanceTraveled);

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
	}
}
