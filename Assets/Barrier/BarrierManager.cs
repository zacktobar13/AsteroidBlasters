using UnityEngine;
using System.Collections;

public class BarrierManager : MonoBehaviour {

	public GameObject barrier;
	public Transform bottomLeft, topLeft, topRight;

	/* Change these variables if art for barrier is ever changed */
	float barrierLength = 1.6f;
	float respawnTime = 0.105f;

	void OnEnable () {
		for (int i = 0; i < (topRight.position.x - topLeft.position.x) / barrierLength; i++) {
			Destroy(Instantiate(barrier, new Vector3(i * barrierLength + topLeft.position.x, topLeft.position.y, 0f), transform.rotation), 3f);
			Destroy(Instantiate(barrier, new Vector3(i * barrierLength + bottomLeft.position.x, bottomLeft.position.y, 0f), transform.rotation), 3f);
		}
		InvokeRepeating("RespawnBarriers", 0f, respawnTime);
	}

	void OnDisable() {
		CancelInvoke();
		foreach (GameObject barrier in GameObject.FindGameObjectsWithTag("Barrier")) {
			Destroy(barrier);
		}
	}

	void RespawnBarriers() {
		Destroy(Instantiate(barrier, new Vector3(topRight.position.x, topLeft.position.y, 0f), transform.rotation), 3f);
		Destroy(Instantiate(barrier, new Vector3(topRight.position.x, bottomLeft.position.y, 0f), transform.rotation), 3f);
	}
}
