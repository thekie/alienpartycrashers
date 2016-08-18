using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]

public class FunkyControl : MonoBehaviour {

	public delegate void FunkAction(GameObject gameObject);
	public static event FunkAction OnFunkStarted;
	public static event FunkAction OnFunkStopped;

	Player player;
	string funkButtonIdentifier;

	void Start () {
		player = GetComponent<Player>();
		funkButtonIdentifier = "Player" + player.id + "_Funk";
	}

	void Update () {
		if (Input.GetButtonDown (funkButtonIdentifier) && OnFunkStarted != null) {
			OnFunkStarted (gameObject);
		}

		if (Input.GetButtonUp (funkButtonIdentifier) && OnFunkStopped != null) {
			OnFunkStopped (gameObject);
		}
	}
}
