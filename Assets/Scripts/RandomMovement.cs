using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
	private float action;
	private bool moving;
	private Rigidbody body;

	void Start () {
		action = Time.time;
		moving = false;
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		/*
		float current = Time.time;
		if (current > action) {
			if (moving) {
				body.AddRelativeForce (new Vector3 (200, 0, 0));
			} else {
				body.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
			}
			action = current + 1.0f;
			moving = !moving;
		}
		*/
		body.AddRelativeForce (new Vector3 (7, 0, 0));
		body.AddRelativeTorque (new Vector3 (0, Random.Range (-1, 2), 0));
	}
}
