using UnityEngine;
using System.Collections;

public class WatcherAnimator : MonoBehaviour {
	public MeshRenderer bodyMesh;

	public AnimationCurve attackAnimationCurve;
	public float attackDuration = 2.0f;

	public Color alertColor = Color.red;
	Color originalColor;

	void Start() {
		originalColor = bodyMesh.material.color;
	}

	public void DoAlarmed() {
		bodyMesh.material.color = alertColor;
	}

	public void DoNormal() {
		bodyMesh.material.color = originalColor;
	}

	public void DoAttackMove() {
		StartCoroutine (AttackMove());
	}

	IEnumerator AttackMove() {
		float elapsedTime = 0;
		Vector3 destination = transform.position;
		destination.y = 0;
		Vector3 start = transform.position;
		while (elapsedTime < attackDuration)
		{
			transform.position = Vector3.Lerp(start, destination, attackAnimationCurve.Evaluate(elapsedTime / attackDuration));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
}
