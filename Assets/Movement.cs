using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class Movement : MonoBehaviour {

	Rigidbody rb;
	public float force = 10.0f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		rb.AddForce (Input.GetAxis("Horizontal")*force, 0, Input.GetAxis("Vertical")*force);
	}
}
