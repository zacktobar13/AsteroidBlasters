using UnityEngine;
using System.Collections;

public class BarrierBehavior : MonoBehaviour {

	public float speed;

	void Update () {
		transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage("PlayerDeath", SendMessageOptions.DontRequireReceiver);
		}
	}
}
