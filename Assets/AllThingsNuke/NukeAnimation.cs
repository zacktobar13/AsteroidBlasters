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
		StartCoroutine("NukeSounds");
		StartCoroutine("NukeText");
		animator.SetBool("Explode", true);
		yield return new WaitForSeconds(.2f);
		animator.SetBool("Explode", false);
	}

	IEnumerator NukeSounds() {
		StartCoroutine("NukeBeepSound");
		soundManager.PlaySound(generalSounds.Sounds[0]); //Initial tick sound.
		soundManager.PlaySound(generalSounds.Sounds[1]); //Bass drop sound
		yield return new WaitForSeconds(.2f);
		soundManager.PlaySound(generalSounds.Sounds[2], .3f); //Explosion sweep sound.	
	}

	IEnumerator NukeBeepSound() {
		soundManager.PlaySound(generalSounds.Sounds[3]);
		yield return new WaitForSeconds(.25f);
		soundManager.PlaySound(generalSounds.Sounds[3]);
		yield return new WaitForSeconds(.25f);
		soundManager.PlaySound(generalSounds.Sounds[3]);
		yield return new WaitForSeconds(.25f);
		soundManager.PlaySound(generalSounds.Sounds[3]);
	}

	IEnumerator NukeText() {     //What a neat coroutine.
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
