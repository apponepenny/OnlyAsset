using UnityEngine;
using System.Collections;

public class tesstbounce : MonoBehaviour {

	public float radius = 0.0F;
	public float power = 2000.0F;
	public float upwardsModifier = 0.0F;

	public Vector3 epicentro;

	void Start() {

		Vector3 explosionPos = transform.position;
		epicentro = explosionPos;

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {

			this.GetComponent<Rigidbody>().AddExplosionForce (-power, transform.position, 0.0f, 0.0f);
			Debug.Log("Player has collided with Bouncer");
		}
	}
}