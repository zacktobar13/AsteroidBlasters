using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmResetPage : MonoBehaviour
{
    public GameObject dataDeletedText;
    public GameObject warningText;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject settingsPage;
    public ScoreManager scoreManager;

    IEnumerator EraseHighScore()
    {
        warningText.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        dataDeletedText.SetActive(true);
        yield return new WaitForSeconds(1f);
        settingsPage.SetActive(true);
        dataDeletedText.SetActive(false);
        scoreManager.resetHighScore();
        warningText.SetActive(true);
        yesButton.SetActive(true);
        noButton.SetActive(true);
        gameObject.SetActive(false);
    }

	public void PressedConfirm()
	{
        StartCoroutine(EraseHighScore());
	}

	public void PressedCancel()
	{
        gameObject.SetActive(false);
        settingsPage.SetActive(true);
    }
}
