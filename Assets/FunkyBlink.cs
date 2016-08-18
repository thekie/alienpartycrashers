using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]

public class FunkyBlink : MonoBehaviour {

	MeshRenderer meshRenderer;
	Color originalColor;

	public Color funkyColor = Color.red;

	void Start()
	{
		meshRenderer = gameObject.GetComponent<MeshRenderer> ();
		originalColor = meshRenderer.material.color;
	}

	void OnEnable()
	{
		FunkyControl.OnFunkStarted += OnFunkStarted;
		FunkyControl.OnFunkStopped += OnFunkStopped;
	}


	void OnDisable()
	{
		FunkyControl.OnFunkStarted -= OnFunkStarted;
		FunkyControl.OnFunkStopped -= OnFunkStopped;
	}
		
	void OnFunkStarted(GameObject gameObject)
	{
		if (gameObject == this.gameObject) {
			meshRenderer.material.color = funkyColor;
		}
	}

	void OnFunkStopped(GameObject gameObject)
	{
		if (gameObject == this.gameObject) {
			meshRenderer.material.color = originalColor;
		}
	}
}
