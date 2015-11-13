using UnityEngine;
using System.Collections;

public class SpriteRotation : MonoBehaviour {

	float rotationRate;

	void Start() {
		rotationRate = Random.Range(-80f, 80f);
	}

	void Update () {	
		transform.Rotate(0f, 0f, rotationRate * Time.deltaTime);
	}
}
