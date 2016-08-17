using UnityEngine;
using System.Collections;

public class SpeedLimiter : MonoBehaviour {

	Rigidbody rb;
	public float maxVelocity = 1.0f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		if (rb.velocity.magnitude > maxVelocity) {
			rb.velocity = rb.velocity.normalized * maxVelocity;
		}
	}
}
