using UnityEngine;
using System.Collections;

public class CenterMovement : MonoBehaviour {
	private enum Stage
	{
		StepLeft,
		Wait,
		StepRight,
		Rotate
	};
	private Rigidbody body;
	private Stage stage;

	private float start;

	public float waitStep = 1.0f;
	public float waitRotate = 1.0f;

	public float centerForce = 25f;
	public float rotateDegrees = 30;

	private Vector3 force;
	private float startRotation;
	private float targetRotation;

	void Start () {
		body = GetComponent<Rigidbody> ();
		stage = Stage.StepLeft;
		start = Time.time;
		force = Vector3.left * centerForce;
	}

	void FixedUpdate () {
		float current = Time.time;
		switch (stage) {
		case Stage.StepLeft:
			if (current - start > waitStep) {
				stage = Stage.Wait;
				start = start + waitStep;
				force = -force;
			} else {
				body.AddRelativeForce (force);
			}
			break;
		case Stage.Wait:
			if (current - start > waitRotate) {
				stage = Stage.StepRight;
				start = start + waitRotate;
			}
			break;
		case Stage.StepRight:
			if (current - start > waitStep) {
				stage = Stage.Rotate;
				start = start + waitStep;
				force = Vector3.zero;
				Vector3 direction = transform.TransformDirection (Vector3.forward);
				startRotation = Vector3.Angle (Vector3.forward, direction);
				if (Vector3.Cross (Vector3.forward, direction).y < 0) {
					startRotation = 360 - startRotation;
				}
				targetRotation = startRotation + (Random.Range (0, 2) == 0 ? -rotateDegrees : rotateDegrees);
			} else {
				body.AddRelativeForce (force);
			}
			break;
		case Stage.Rotate:
			if (current - start > waitRotate) {
				transform.rotation = Quaternion.AngleAxis (targetRotation, Vector3.up);
				stage = Stage.StepLeft;
				force = Vector3.left * centerForce;
				start = start + waitRotate;
			} else {
				float currentRotation = (targetRotation - startRotation) * (current - start) / waitRotate + startRotation;
				transform.rotation = Quaternion.AngleAxis (currentRotation, Vector3.up);
			}
			break;
		}
	}

}
