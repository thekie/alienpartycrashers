using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(Player))]

public class FunkyBlink : MonoBehaviour {

	MeshRenderer meshRenderer;
	Color originalColor;
	Player player;

	public Color funkyColor = Color.red;

	void Start()
	{
		player = gameObject.GetComponent<Player> ();
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
		
	void OnFunkStarted(int playerID)
	{
		if (playerID == player.id) {
			meshRenderer.material.color = funkyColor;
		}
	}

	void OnFunkStopped(int playerID)
	{
		if (playerID == player.id) {
			meshRenderer.material.color = originalColor;
		}
	}
}
