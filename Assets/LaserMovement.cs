using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {

	void FixedUpdate () {
		gameObject.transform.Translate(15f * Time.deltaTime, 0f, 0f);	
	}
}
