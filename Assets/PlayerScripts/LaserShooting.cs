using UnityEngine;
using System.Collections;

public class LaserShooting : MonoBehaviour {

	public GameObject laser;
	public Transform laserSpawn;

	public void FireLaser() {
		Destroy(Instantiate(laser, laserSpawn.position, laserSpawn.rotation), 4f);
	}
}
