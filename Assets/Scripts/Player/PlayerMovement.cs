using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour 
{
	Rigidbody2D rigidBody;
	public float thrustForce;
	public bool canMove = false;
	public SoundManager soundManager;
	public GeneralSounds generalSounds;
	public Text countdown;
	bool isThrustPressed = false;

	void Start () {
		rigidBody = this.GetComponent<Rigidbody2D>();
	}

	void OnEnable() 
	{
		countdown.text = "";
		rigidBody = this.GetComponent<Rigidbody2D>();
		transform.position = new Vector2(-7.6f, 0f);
		rigidBody.isKinematic = true;
		rigidBody.velocity = Vector2.zero;
		isThrustPressed = false;
		StartCoroutine("GameStartCountdown");
	}

	void Update () 
	{
		if (isThrustPressed)
			Thrust();
	}

	public void OnThrustDown()
	{
		isThrustPressed = true;
	}

	public void OnThrustUp()
	{
		isThrustPressed = false;
	}

	public void Thrust()
	{
		rigidBody.AddForce(new Vector2(0, thrustForce) * Time.deltaTime);
	}

	IEnumerator GameStartCountdown() {
		soundManager.PlaySound(generalSounds.Sounds[3]);
		countdown.text = "3";
		yield return new WaitForSeconds(.6f);
		soundManager.PlaySound(generalSounds.Sounds[3]);
		countdown.text = "2";
		yield return new WaitForSeconds(.6f);
		soundManager.PlaySound(generalSounds.Sounds[3]);
		countdown.text = "1";
		yield return new WaitForSeconds(.6f);
		soundManager.PlaySound(generalSounds.Sounds[4]);
		countdown.text = "Go!";
		canMove = true;
		rigidBody.isKinematic = false;
		yield return new WaitForSeconds(.6f);
		countdown.text = "";
	}
}
