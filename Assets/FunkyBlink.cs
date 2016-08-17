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
	}
		
	void OnFunkStarted()
	{
		meshRenderer.material.color = funkyColor;
	}

	void OnFunkStopped()
	{
		meshRenderer.material.color = originalColor;
	}
}
