using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Player))]

public class Movement : MonoBehaviour {

	Rigidbody rb;
	string horizontalAxisIdentifier;
	string verticalAxisIdentifier;

	public float force = 10.0f;
	private float eps = 1e-4f;

	LastActivity lastActivity;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		int playerID = GetComponent<Player>().id;
		horizontalAxisIdentifier = "Player" + playerID + "_Horizontal";
		verticalAxisIdentifier = "Player" + playerID + "_Vertical";
		lastActivity = GetComponent<LastActivity> ();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis (horizontalAxisIdentifier);
		float vertical = Input.GetAxis (verticalAxisIdentifier);
		rb.AddForce (horizontal * force, 0, vertical * force);
		if (lastActivity != null) {
			if (Mathf.Abs (horizontal) > eps || Mathf.Abs (vertical) > eps) {
				lastActivity.updateLastActivity ();
			}
		}
	}
}