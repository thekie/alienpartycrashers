using UnityEngine;
using System.Collections;

public class InitRandomRotation : MonoBehaviour {
	void Start () {
		transform.rotation = Quaternion.AngleAxis (360 * Random.value, Vector3.up);
	}
}
