using UnityEngine;
using System.Collections;

public class CenterMovement : MonoBehaviour {
	private enum Stage
	{
		Center,
		Tangent,
		Wait
	};
	private Rigidbody body;
	private Vector3 center;
	private Stage stage;
	private Stage prevStage;
	private float start;
	public float waitCenter = 1.0f;
	public float waitTangent = 0.5f;
	public float waitDecel = 0.09f;
	public float centerForce = 25f;
	public float tangentForce = 10f;
	private Vector3 force;

	void Start () {
		body = GetComponent<Rigidbody> ();
		center = transform.localPosition + Vector3.forward * 0.1f;
		stage = Stage.Center;
		start = Time.time;
		force = Vector3.zero;
	}

	void FixedUpdate () {
		float current = Time.time;
		switch (stage) {
		case Stage.Center:
			if (current - start > waitCenter) {
				prevStage = Stage.Center;
				stage = Stage.Wait;
				start = start + waitCenter;
				force = Vector3.zero;
			}
			break;
		case Stage.Tangent:
			if (current - start > waitTangent) {
				prevStage = Stage.Tangent;
				stage = Stage.Wait;
				start = start + waitTangent;
				force = Vector3.zero;
			}
			break;
		case Stage.Wait:
			if (current - start > waitDecel) {
				if (prevStage == Stage.Tangent) {
					force = (center - transform.localPosition).normalized * centerForce * (Random.value / 4f + 0.75f);
					stage = Stage.Center;
				} else {
					force = Vector3.Cross (center - transform.localPosition, Vector3.up).normalized * tangentForce * (Random.value - 0.5f);
					stage = Stage.Tangent;
				}
				start = start + waitDecel;
				prevStage = Stage.Wait;
			}
			break;
		}
		body.AddForce (force);
	}

	public void setCenter(Vector3 newCenter) {
		center = newCenter + Vector3.forward * 0.1f;
	}
}
