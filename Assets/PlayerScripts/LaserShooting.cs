using UnityEngine;
using System.Collections;

public class LaserShooting : MonoBehaviour {

	public GameObject laser;
	public GameObject laserParticles;
	public Transform laserSpawn;
	public Transform laserParticleSpawn;

	public void FireLaser() {
		Destroy(Instantiate(laser, laserSpawn.position, laserSpawn.rotation), 4f);
		Destroy(Instantiate(laserParticles, laserParticleSpawn.position, laserParticleSpawn.rotation), 2f);
	}
}
