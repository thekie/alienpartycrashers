using UnityEngine;
using System.Collections;

public class ActorsController : MonoBehaviour {

	public int numActors = 30;
	public GameObject actorPrefab;
	public Transform parent;
	public float placementRadius = 10f;
	public float actorRadius = 0.5f;

	private CenterMovement[] actors;

	void Start () {
		actors = new CenterMovement[numActors];
		Vector3[] prevPlacement = new Vector3[numActors];
		for (int i = 0; i < numActors; i++) {
			Vector3 pos;
			bool good;
			do {
				good = true;
				pos = Vector3.forward * placementRadius * Random.value;
				pos = Quaternion.AngleAxis (360f * Random.value, Vector3.up) * pos;
				for (int j = 0; j < i; j++) {
					if ((prevPlacement [j] - pos).sqrMagnitude < 4 * actorRadius * actorRadius) {
						good = false;
						break;
					}
				}
			} while (!good);
			GameObject go = Instantiate (actorPrefab, parent) as GameObject;
			go.transform.localPosition = pos;
			prevPlacement [i] = pos;
			actors [i] = go.GetComponent<CenterMovement> ();
		}
	}

}
