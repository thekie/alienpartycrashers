using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FunkyManager : MonoBehaviour {
	float funkMeter;
	List<int> funkingPlayers = new List<int> ();

	public Texture2D emptyBar;
	public Texture2D fullBar;

	void Start () {
		FunkyControl.OnFunkStarted += OnFunkStarted;
		FunkyControl.OnFunkStopped += OnFunkStopped;
	}

	void OnFunkStopped (int playerID) {
		funkingPlayers.Remove (playerID);
	}

	void OnFunkStarted (int playerID) {
		bool found = false;
		foreach (int player in funkingPlayers) {
			if (player == playerID) {
				found = true;
				break;
			}
		}
		if (!found) {
			funkingPlayers.Add (playerID);
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
