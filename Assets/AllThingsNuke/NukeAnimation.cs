using UnityEngine;
using System.Collections;

public class NukeAnimation : MonoBehaviour {

	public Animator animator;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;

	public void NukeExplodeAnimation() {
		Debug.Log("NukeExplodeAnimation");
		StartCoroutine("NukeFlash");
	}

	IEnumerator NukeFlash() {
		StartCoroutine("NukeSounds");
		animator.SetBool("Explode", true);
		yield return new WaitForSeconds(.2f);
		animator.SetBool("Explode", false);
	}

	IEnumerator NukeSounds() {
		soundManager.PlaySound(generalSounds.Sounds[0]); //Initial tick sound.
		soundManager.PlaySound(generalSounds.Sounds[1]); //Bass drop sound
		yield return new WaitForSeconds(.2f);
		soundManager.PlaySound(generalSounds.Sounds[2]); //Explosion sweep sound.	
	}
}
