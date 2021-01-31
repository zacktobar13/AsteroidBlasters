using UnityEngine;
using System.Collections;

public class NukeAnimation : MonoBehaviour {

	public Animator animator;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;
	public GameObject nukeText, shieldText, fiftyPointsText;

	public void NukeExplodeAnimation() {
		StartCoroutine("NukeFlash");
	}

	IEnumerator NukeFlash() {
		StartCoroutine("NukeText");
		animator.SetBool("Explode", true);
		yield return new WaitForSeconds(.2f);
		animator.SetBool("Explode", false);
	}

	IEnumerator NukeText() {  
		fiftyPointsText.SetActive(false);
		shieldText.SetActive(false);
		nukeText.SetActive(true);
		yield return new WaitForSeconds(.15f);
		nukeText.SetActive(false);
		yield return new WaitForSeconds(.15f);
		nukeText.SetActive(true);
		yield return new WaitForSeconds(.15f);
		nukeText.SetActive(false);
		yield return new WaitForSeconds(.15f);
		nukeText.SetActive(true);
		yield return new WaitForSeconds(.15f);
		nukeText.SetActive(false);
		yield return new WaitForSeconds(.15f);
		nukeText.SetActive(true);
		yield return new WaitForSeconds(.15f);
		nukeText.SetActive(false);
	}
}
