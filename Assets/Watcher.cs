using UnityEngine;
using System.Collections;

public class Watcher : MonoBehaviour {

	enum State {Searching, Alarmed, Attack};
	State currentState = State.Searching;
	public float moveRadius = 20.0f;
	public float moveSpeed = 10.0f;
	public float rotationSpeed = 10.0f;

	public float searchDelay = 2.0f;

	void Start() {
		StartCoroutine(Searching());
	}

	Vector3 GetRandomTargetPosition() {
		float angle = Random.Range (0, 360);
		Vector3 direction = new Vector3(
			Mathf.Cos(Mathf.Deg2Rad * angle), 
			0, 
			Mathf.Sin(Mathf.Deg2Rad * angle));
		Vector3 position = direction * moveRadius;
		position.y = transform.position.y;
		return position;
	}

	IEnumerator Searching() {
		while (currentState == State.Searching) {
			Vector3 target = GetRandomTargetPosition ();
			yield return LookAtPosition (target);
			yield return new WaitForSeconds (searchDelay);
			yield return MoveToPosition (target);
		}
	}

	IEnumerator LookAtPosition(Vector3 target)
	{
		float elapsedTime = 0;
		Quaternion lookAt = Quaternion.LookRotation (target - transform.position);

		float angle = 0;
		Vector3 axis = Vector3.zero;
		lookAt.ToAngleAxis (out angle, out axis);

		float time = angle / rotationSpeed;
		while (elapsedTime < time)
		{
			transform.rotation = Quaternion.Slerp(
				transform.rotation, 
				lookAt, 
				(elapsedTime / time)
			);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator MoveToPosition(Vector3 destination)
	{
		float elapsedTime = 0;
		float distance = (destination-transform.position).magnitude;
		float time = distance / moveSpeed;
		while (elapsedTime < time)
		{
			transform.position = Vector3.Lerp(transform.position, destination, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
}
