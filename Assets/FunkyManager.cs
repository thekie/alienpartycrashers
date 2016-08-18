using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FunkyManager : MonoBehaviour {
	float funkMeter;
	List<GameObject> funkingPlayers = new List<GameObject> ();

	public Texture2D emptyBar;
	public Texture2D fullBar;

	void Start () {
		FunkyControl.OnFunkStarted += OnFunkStarted;
		FunkyControl.OnFunkStopped += OnFunkStopped;
	}

	void OnFunkStopped (GameObject go) {
		funkingPlayers.Remove (go);
	}

	void OnFunkStarted (GameObject go) {
		bool found = false;
		foreach (GameObject player in funkingPlayers) {
			if (player == go) {
				found = true;
				break;
			}
		}
		if (!found) {
			funkingPlayers.Add (go);
		}
	}

	void Update () {
		if (funkingPlayers.Count > 0) {
			funkMeter += Time.deltaTime;
		}
	}

	void OnGUI() {
		int value = Mathf.Min (300, Mathf.RoundToInt(funkMeter * 6));
		GUI.DrawTexture (new Rect (10, 10, 300, 50), emptyBar);
		GUI.DrawTexture (new Rect (10, 10, value, 50), fullBar);
	}
}
