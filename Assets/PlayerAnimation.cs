using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

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
