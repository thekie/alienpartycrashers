using UnityEngine;
using System.Collections;

public class ActorsController : MonoBehaviour {

	public GameObject actor;
	public Transform parent;

	void Start () {
		for (int i = 0; i < 30; i++) {
			Vector3 pos = Vector3.forward * 15f * (0.5f + (i >= 15 ? 0.5f : 0f));
			pos = Quaternion.AngleAxis (360 * (i % 15) / 15f, Vector3.up) * pos;
			GameObject go = Instantiate (actor, parent) as GameObject;
			go.transform.localPosition = pos;
		}
	}
}
