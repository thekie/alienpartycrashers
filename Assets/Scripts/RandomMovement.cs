using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
	private enum Behavior {Random, Center};
	private Behavior current;
	private Rigidbody body;
	private int maxDistance = 15;

	void Start () {
		body = GetComponent<Rigidbody> ();
		current = Behavior.Random;
	}

	void FixedUpdate () {
		switch (current) {
		case Behavior.Random:
			body.AddRelativeForce (Vector3.forward * 10f);
			body.AddRelativeTorque (new Vector3 (0, Random.Range (-1, 2) * 5f, 0));
			if (transform.position.sqrMagnitude > maxDistance * maxDistance) {
				current = Behavior.Center;
			}
			break;
		case Behavior.Center:
			Vector3 direction = transform.TransformPoint (Vector3.forward) - transform.position;
			direction.y = 0;
			Vector3 desired = -transform.position;
			desired.y = 0;
			Vector3 next = Vector3.RotateTowards (direction, desired, Mathf.PI / 300, 1.0f);
			body.MoveRotation (Quaternion.LookRotation (next));
			float sqrDistance = transform.position.sqrMagnitude;
			if (Vector3.Angle (direction, desired) < 10) {
				body.AddRelativeForce (Vector3.forward * 0.5f);
			}
			if (sqrDistance < maxDistance * maxDistance) {
				current = Behavior.Random;
			}
			break;
		} 
	}
}
