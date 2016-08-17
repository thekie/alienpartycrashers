using UnityEngine;
using System.Collections;

public class FunkyControl : MonoBehaviour {

	public delegate void FunkAction();
	public static event FunkAction OnFunkStarted;
	public static event FunkAction OnFunkStopped;

	void Update () {
		if (Input.GetButtonDown ("Fire1") && OnFunkStarted != null) {
			OnFunkStarted ();
		}

		if (Input.GetButtonUp ("Fire1") && OnFunkStopped != null) {
			OnFunkStopped ();
		}
	}
}
