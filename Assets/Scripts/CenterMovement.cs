using UnityEngine;
using System.Collections;

public class CenterMovement : MonoBehaviour {
	private Rigidbody body;

	void Start () {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
	}
}
