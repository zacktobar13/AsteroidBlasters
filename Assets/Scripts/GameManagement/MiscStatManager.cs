using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MiscStatManager : MonoBehaviour {

	//[HideInInspector]
	public int shieldsCollected, nukesCollected;
	//[HideInInspector]
	public float lasersFired, asteroidsDestroyed, laserAccuracy, distanceTraveled;

	public Text distanceTraveledText, lasersFiredText, asteroidsDestroyedText, laserAccuracyText, shieldsCollectedText, nukesCollectedText;

	public void CalculateAllStats() {
		laserAccuracy = asteroidsDestroyed / lasersFired;
		string accuracyString = string.Format("{0:0.0%}", laserAccuracy);
		string distanceString = string.Format("{0:0.00}", distanceTraveled);
		laserAccuracyText.text = accuracyString;

		distanceTraveledText.text = distanceString + " AU";
		lasersFiredText.text = lasersFired.ToString();
		asteroidsDestroyedText.text = asteroidsDestroyed.ToString();
		shieldsCollectedText.text = shieldsCollected.ToString();
		nukesCollectedText.text = nukesCollected.ToString();
	}
}
