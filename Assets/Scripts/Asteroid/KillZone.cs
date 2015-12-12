using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage("GetRekt");
			if(other.gameObject.hasShield) {
				this.SendMessage("GetRekt");
			}
		}
	}
}
