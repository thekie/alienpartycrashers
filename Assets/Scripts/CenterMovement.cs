using UnityEngine;
using System.Collections;

public class CenterMovement : MonoBehaviour {
	private enum Stage
	{
		Center,
		Tangent
	};
	private Rigidbody body;
	private Vector3 center;
	private Stage stage;
	private float start;
	private float waitTime = 2.0f;
	public float centerForce = 25f;
	public float tangentForce = 10f;

	void Start () {
		body = GetComponent<Rigidbody> ();
		center = transform.position + Vector3.forward * 0.1f;
		stage = Stage.Center;
		start = Time.time;
	}

	void FixedUpdate () {
		switch (stage) {
		case Stage.Center:
			if (Time.time - start > waitTime) {
				body.AddForce ((center - transform.position).normalized * centerForce * (Random.value / 2f + 0.5f));
				stage = Stage.Tangent;
				start = Time.time;
			}
			break;
		case Stage.Tangent:
			if (Time.time - start > waitTime) {
				body.AddForce (Vector3.Cross (center - transform.position, Vector3.up).normalized * tangentForce * (Random.value - 1f));
				stage = Stage.Center;
				start = Time.time;
			}
			break;
		}
	}
}
