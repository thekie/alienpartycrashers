using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Player))]

public class Movement : MonoBehaviour {

	Rigidbody rb;
	string horizontalAxisIdentifier;
	string verticalAxisIdentifier;
	CenterMovement center;

	public float force = 10.0f;
	public bool forceApplied = false;
	const float eps = 0.00001f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		int playerID = GetComponent<Player>().id;
		horizontalAxisIdentifier = "Player" + playerID + "_Horizontal";
		verticalAxisIdentifier = "Player" + playerID + "_Vertical";
		center = GetComponent<CenterMovement> ();
	}

	void FixedUpdate () {
		bool forcePresent = Mathf.Abs (Input.GetAxis (horizontalAxisIdentifier)) > eps ||
		                    Mathf.Abs (Input.GetAxis (verticalAxisIdentifier)) > eps;
		rb.AddForce (
			Input.GetAxis(horizontalAxisIdentifier)*force, 
			0, 
			Input.GetAxis(verticalAxisIdentifier)*force
		);
		if (forceApplied && !forcePresent && center != null) {
			center.setCenter (transform.localPosition);
		}
		forceApplied = forcePresent;
	}
}