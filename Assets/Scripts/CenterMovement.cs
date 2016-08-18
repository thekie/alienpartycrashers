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
	public float waitCenter = 1.0f;
	public float waitTangent = 1.0f;
	public float centerForce = 25f;
	public float tangentForce = 10f;
	public bool notifyStages = false;
	private Vector3 force;

	void Start () {
		body = GetComponent<Rigidbody> ();
		center = transform.localPosition + Vector3.forward * 0.1f;
		stage = Stage.Center;
		start = Time.time;
		force = Vector3.zero;
	}

	void FixedUpdate () {
		switch (stage) {
		case Stage.Center:
			if (Time.time - start > waitTangent) {
				force = (center - transform.localPosition).normalized * centerForce * (Random.value / 2f + 0.5f);
				stage = Stage.Tangent;
				start = Time.time;
				if (notifyStages) {
					Debug.Log (stage);
				}
			}
			break;
		case Stage.Tangent:
			if (Time.time - start > waitCenter) {
				force = Vector3.Cross (center - transform.localPosition, Vector3.up).normalized * tangentForce * (Random.value - 0.5f);
				stage = Stage.Center;
				start = Time.time;
				if (notifyStages) {
					Debug.Log (stage);
				}
			}
			break;
		}
		body.AddRelativeForce (force);
	}

	public void setCenter(Vector3 newCenter) {
		center = newCenter + Vector3.forward * 0.1f;
	}
}
