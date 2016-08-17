using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Player))]

public class Movement : MonoBehaviour {

	Rigidbody rb;
	string horizontalAxisIdentifier;
	string verticalAxisIdentifier;

	public float force = 10.0f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		int playerID = GetComponent<Player>().id;
		horizontalAxisIdentifier = "Player" + playerID + "_Horizontal";
		verticalAxisIdentifier = "Player" + playerID + "_Vertical";
	}

	void FixedUpdate () {
		rb.AddForce (
			Input.GetAxis(horizontalAxisIdentifier)*force, 
			0, 
			Input.GetAxis(verticalAxisIdentifier)*force
		);
	}
}