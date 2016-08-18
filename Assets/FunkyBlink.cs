using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]

public class FunkyBlink : MonoBehaviour {

	MeshRenderer meshRenderer;
	Color originalColor;
	public TempTentacleAnimScript tentacleAnimator;

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
		
	void OnFunkStarted(GameObject gameObject)
	{
		if (gameObject == this.gameObject) {
			if (tentacleAnimator == null) {
				meshRenderer.material.color = funkyColor;
			} else {
				tentacleAnimator.DoFunkyColors (true);
			}
		}
	}

	void OnFunkStopped(GameObject gameObject)
	{
		if (gameObject == this.gameObject) {
			if (tentacleAnimator == null) {
				meshRenderer.material.color = originalColor;
			} else {
				tentacleAnimator.DoFunkyColors (false);
			}
		}
	}
}
