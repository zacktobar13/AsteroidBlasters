using UnityEngine;
using System.Collections;

public class NukeSpawner : MonoBehaviour {

	public GameObject nuke;

	public void SpawnNuke() {
		Destroy(Instantiate(nuke, transform.position, transform.rotation), 6f);
	}
}
