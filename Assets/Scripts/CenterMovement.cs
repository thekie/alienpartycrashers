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
	public float waitTangent = 1.0f;
	public float waitDecel = 0.2f;
	public float centerForce = 25f;
	public float tangentForce = 10f;
	private Vector3 force;
	public TempTentacleAnimScript tentacleAnimator;

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
			if (Time.time - start > waitCenter) {
				prevStage = Stage.Center;
				stage = Stage.Wait;
				start = Time.time;
				force = Vector3.zero;
			}
			break;
		case Stage.Tangent:
			if (Time.time - start > waitTangent) {
				prevStage = Stage.Tangent;
				stage = Stage.Wait;
				start = Time.time;
				force = Vector3.zero;
			}
			break;
		case Stage.Wait:
			if (Time.time - start > waitDecel) {
				if (prevStage == Stage.Tangent) {
					force = (center - transform.localPosition).normalized * centerForce * (Random.value / 4f + 0.75f);
					stage = Stage.Center;
					if (tentacleAnimator != null) {
						tentacleAnimator.anim.SetTrigger ("waltzLeft");
					}
				} else {
					force = Vector3.Cross (center - transform.localPosition, Vector3.up).normalized * tangentForce * (Random.value - 0.5f);
					stage = Stage.Tangent;
					if (tentacleAnimator != null) {
						tentacleAnimator.anim.SetTrigger ("waltzRight");
					}
				}
				start = Time.time;
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
