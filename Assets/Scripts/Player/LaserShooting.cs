using UnityEngine;
using System.Collections;

public class LaserShooting : MonoBehaviour {

	public GameObject laser;
	public ParticleSystem laserParticles;
	public Transform laserSpawn;
	public MiscStatManager miscStatManager;

	void Start() {
		laserParticles.Stop();
	}
	public void FireLaser() {
		miscStatManager.lasersFired += 1;
		Destroy(Instantiate(laser, laserSpawn.position, laserSpawn.rotation), 4f);
		StartCoroutine("ShootParticles");
	}

	public IEnumerator ShootParticles() {
		laserParticles.Play();
		yield return new WaitForSeconds(.3f);
		laserParticles.Stop();
	}
}
