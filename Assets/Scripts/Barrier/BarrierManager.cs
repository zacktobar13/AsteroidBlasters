using UnityEngine;
using System.Collections;

public class BarrierManager : MonoBehaviour {

	public GameObject topBarrier, bottomBarrier;
	public Transform bottomLeft, topLeft, topRight;

	/* Change these variables if art for barrier is ever changed */
	float respawnTime = 1.2f;
	float timeUntilFirstRespawn = 0f;

	void OnEnable () {
		Destroy(Instantiate(topBarrier, new Vector3(topLeft.position.x, topLeft.position.y, 0f), transform.rotation), 4f);
		Destroy(Instantiate(bottomBarrier, new Vector3(bottomLeft.position.x, bottomLeft.position.y, 0f), transform.rotation), 4f);
		InvokeRepeating("RespawnBarriers", timeUntilFirstRespawn, respawnTime);
	}

	void OnDisable() {
		CancelInvoke();
		foreach (GameObject barrier in GameObject.FindGameObjectsWithTag("Barrier")) {
			Destroy(barrier);
		}
	}

	void RespawnBarriers() {
		Destroy(Instantiate(topBarrier, new Vector3(topRight.position.x, topLeft.position.y, 0f), transform.rotation), 4f);
		Destroy(Instantiate(bottomBarrier, new Vector3(topRight.position.x, bottomLeft.position.y, 0f), transform.rotation), 4f);
	}
}
