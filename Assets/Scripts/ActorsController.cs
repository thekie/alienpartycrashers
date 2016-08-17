using UnityEngine;
using System.Collections;

public class ActorsController : MonoBehaviour {

	public GameObject actor;
	public Transform parent;

	void Start () {
		for (int i = 0; i < 50; i++) {
			GameObject go = Instantiate (actor, parent) as GameObject;
			go.transform.localPosition = new Vector3 ((i % 5 - 3) * 4, 0, 4 * (i / 5));
		}
	}
}
