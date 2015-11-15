using UnityEngine;
using System.Collections;

public class SpriteRotation : MonoBehaviour {

	float rotationRate;
	public float rotationMin, rotationMax;

	void Start() {
		rotationRate = Random.Range(rotationMin, rotationMax);
	}

	void Update () {	
		transform.Rotate(0f, 0f, rotationRate * Time.deltaTime);
	}
}
