using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FunkyManager : MonoBehaviour {
	public float funkMeter;
	public float funkingRange = 20f;
	List<GameObject> funkingPlayers = new List<GameObject> ();
	public float funkingClose = 5.0f;
	private bool megaFunk = false;

	public Image fillerBar;

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
			funkMeter += Time.deltaTime / funkingRange;
			megaFunk = false;
			float minDistance = float.MaxValue;
			for (int i = 0; i < funkingPlayers.Count; i++) {
				for (int j = 0; j < i; j++) {
					float distance = Vector3.Distance (funkingPlayers[i].transform.position,
						funkingPlayers[j].transform.position);
					if (distance < minDistance) {
						minDistance = distance;
					}
				}
				if (minDistance < funkingClose) {
					megaFunk = true;
					break;
				}
			}
			if (megaFunk) {
				funkMeter += Time.deltaTime / funkingRange;
			}
		}
		if (funkMeter >= 1f) {
			SceneManager.LoadScene ("PartyPooper");
		}
	}

	void OnGUI() {
		fillerBar.fillAmount = funkMeter;
	}
}
