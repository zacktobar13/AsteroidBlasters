using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			PlayerStatusManager playerStatus = other.gameObject.GetComponent<PlayerStatusManager>();
			if(playerStatus.hasShield) {
				this.SendMessage("Death", SendMessageOptions.DontRequireReceiver);
			}
			other.gameObject.SendMessage("PlayerDeath");
		}
	}
}
