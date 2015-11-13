using UnityEngine;
using System.Collections;

public class AsteroidStatusManager : MonoBehaviour {

	public GameObject asteroidPieces;

	public void GetRekt() {
		Instantiate(asteroidPieces, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
	}
	
	public void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.tag);
		Instantiate(asteroidPieces, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
	}
}
