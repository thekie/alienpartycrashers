using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	[SerializeField] float rotationSpeed = 90f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, transform.right, Time.deltaTime * rotationSpeed);
	}
}
