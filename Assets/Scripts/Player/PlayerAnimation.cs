using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	#pragma warning disable 0108
	Rigidbody2D rigidbody;
	Animator animator;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
		animator.SetFloat("Velocity", rigidbody.velocity.y);
	}
}
