using UnityEngine;
using System.Collections;

public class ActorsController : MonoBehaviour {

	public GameObject actor;
	public Transform parent;
	private CenterMovement[] actors;
	private float startTime;

	void Start () {
		startTime = Time.time;
		int numActors = 30;
		actors = new CenterMovement[numActors];
		for (int i = 0; i < numActors; i++) {
			Vector3 pos = Vector3.forward * 15f * (0.5f + (i >= 15 ? 0.5f : 0f));
			pos = Quaternion.AngleAxis (360 * (i % 15) / 15f, Vector3.up) * pos;
			GameObject go = Instantiate (actor, parent) as GameObject;
			go.transform.localPosition = pos;
			actors [i] = go.GetComponent<CenterMovement> ();
		}
	}

	void Update() {
		float delta = (Time.time - startTime) * 1f;
		for (int i = 0; i < actors.Length; i++) {
			Vector3 pos = Vector3.forward * 15f * (0.5f + (i >= 15 ? 0.5f : 0f));
			pos = Quaternion.AngleAxis (360 * (i % 15) / 15f + delta, Vector3.up) * pos;
			actors [i].setCenter (pos);
		}
	}
}
