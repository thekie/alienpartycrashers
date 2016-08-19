using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(MeshCollider))]
[RequireComponent (typeof(WatcherAnimator))]

public class Watcher : MonoBehaviour {

	enum State {Searching, Alarmed, Attack};
	State currentState = State.Searching;

	public float moveRadius = 20.0f;
	public float moveSpeed = 10.0f;
	public float searchRadius = 3.0f;

	public float attackDelay = 0.5f;

	public float explosionForce = 100.0f;
	public float explosionRadius = 4.0f;

	public FunkyManager funkManager;

	public AnimationCurve animationCurve;

	WatcherAnimator watcherAnimator;
	GameObject currentHomingTarget;
	public Animator animator;

	List<FunkyControl> funkyPlayers = new List<FunkyControl>();

	void Start() {
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Player");

		watcherAnimator = GetComponent<WatcherAnimator> ();
		StartCoroutine(Searching());
		foreach (GameObject go in gameObjects) {
			FunkyControl player = go.GetComponent<FunkyControl> ();
			if (player != null) {
				funkyPlayers.Add (player);
			}
		}
	}

	void SwitchToAlarmed(GameObject target) {
		if (currentState == State.Alarmed && target == currentHomingTarget) {
			return;
		}
			
		if (currentHomingTarget && currentHomingTarget.GetComponent<FunkyControl> ().isFunky) {
			Debug.Log ("Old target is still funky");
			return;
		}


		watcherAnimator.DoAlarmed ();
		animator.SetTrigger ("alarmed");

		Debug.Log ("SwitchToAlarmed");
		currentState = State.Alarmed;
		StopAllCoroutines ();
		StartCoroutine (Homing (target));
	}

	void SwitchToAttack(GameObject target) {
		
		if (currentState == State.Attack) {
			return;
		}

		SongManager.Instance.PlayAttack();

		currentHomingTarget = null;

		Debug.Log ("SwitchToAttack");
		Player player = target.GetComponent<Player> ();
		if (player != null) {
			currentState = State.Attack;
			StopAllCoroutines ();
			StartCoroutine (Attacking (target));
		}
	}

	void SwitchToSearching() {
		if (currentState == State.Searching) {
			return;
		}

		currentHomingTarget = null;

		Debug.Log ("SwitchToSearching");
		animator.SetTrigger ("searching");
		currentState = State.Searching;
		StopAllCoroutines ();
		watcherAnimator.DoNormal ();
		StartCoroutine(Searching());
	}

	Vector3 GetRandomTargetPosition() {
		Vector2 position = Random.insideUnitCircle * moveRadius;
		return new Vector3(position.x, transform.position.y, position.y);
	}

	IEnumerator Searching() {
		while (currentState == State.Searching) {
			yield return MoveToPosition (GetRandomTargetPosition ());
		}
	}

	IEnumerator Homing(GameObject gameObject) {
//		SongManager.Instance.PlayAlarm();
		currentHomingTarget = gameObject;
		Vector3 targetPosition = gameObject.transform.position;
		targetPosition.y = transform.position.y;
		yield return MoveToPosition (targetPosition);
		currentHomingTarget = null;
		SwitchToSearching ();
	}

	IEnumerator Attacking(GameObject gameObject) {
		while (currentState == State.Attack) {
			Vector3 homingPosition = gameObject.transform.position;
			homingPosition.y = transform.position.y;

			Vector3 preparePosition = homingPosition;
			preparePosition.y += 1;

			yield return MoveToPosition (homingPosition);

			animator.SetTrigger ("prepareDive");

			yield return MoveToPosition (preparePosition);

			yield return new WaitForSeconds (attackDelay);

			if (IsInSearchRadius (gameObject)) {
				animator.SetTrigger ("slamDown");
				watcherAnimator.DoAttackMove ();
				Vector3 attackPosition = transform.position;
				attackPosition.y = 0.5f;
				yield return new WaitForSeconds (watcherAnimator.attackDuration * 0.05f);
				AddExplosionForceForAllPlayersAtPosition (attackPosition);
				FunkyControl.StopTheFunk ();
				yield return new WaitForSeconds (watcherAnimator.attackDuration);
				yield return MoveToPosition (homingPosition);
				SwitchToSearching ();
			} else {
				animator.SetTrigger ("cancelDive");
				SwitchToSearching ();
			}
		}
	}

	void AddExplosionForceForAllPlayersAtPosition(Vector3 position) {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players) {
			Rigidbody rb = player.GetComponent<Rigidbody> ();
			rb.AddExplosionForce(explosionForce, position, explosionRadius);
		}
	}

	IEnumerator MoveToPosition(Vector3 destination)
	{
		float elapsedTime = 0;
		float distance = (destination-transform.position).magnitude;
		float time = distance / moveSpeed;
		Vector3 start = transform.position;
		while (elapsedTime < time)
		{
			transform.position = Vector3.Lerp(start, destination, animationCurve.Evaluate(elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}

	void Update() {
		foreach (FunkyControl funkyControl in funkyPlayers) {
			if (funkyControl.isFunky) {
				if (IsInSearchRadius (funkyControl.gameObject)) {
					SwitchToAttack (funkyControl.gameObject);
					break;
				} else {
					if (currentState != State.Attack) {
						SwitchToAlarmed (funkyControl.gameObject);
					}
				}
			}
		}
	}

	bool IsInSearchRadius(GameObject gameObject) {
		Vector2 goPos = new Vector2 (
			gameObject.transform.position.x,
			gameObject.transform.position.z
		);

		Vector2 watcherPos = new Vector2 (
			transform.position.x,
			transform.position.z
		);

		return (watcherPos - goPos).magnitude < searchRadius;
	}
}
