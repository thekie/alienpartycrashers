using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FunkyManager : MonoBehaviour {
	public float funkMeter;
	GameObject[] players;

	public AnimationCurve decreaseCurve;

	public float maxDistance = 30.0f;
	public float maxFunk = 900.0f;
	public float activityThreshold = 15f;
	public Image fillerBar;
	public Image[] activityIndicators;
	public Color activityColor = Color.blue;

	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
		
	void Update () {
		funkMeter -= Mathf.Max (Time.deltaTime * decreaseCurve.Evaluate (funkMeter), 0);
		funkMeter = Mathf.Max (funkMeter, 0);

		List<GameObject> funkyPlayers = new List<GameObject> ();
		List<bool> activePlayers = new List<bool> ();
		int totalActive = 0;

		foreach (GameObject go in players) {
			FunkyControl funkyControl = go.GetComponent<FunkyControl> ();
			float lastActivity = -1e4f;
			if (funkyControl.isFunky) {
				funkyPlayers.Add (funkyControl.gameObject);
				lastActivity = Time.time;
			}
			Movement movement = go.GetComponent<Movement> ();
			lastActivity = Mathf.Max (lastActivity, movement.lastActivity);
			bool active = Time.time - lastActivity < activityThreshold;
			activePlayers.Add (active);
			if (active) {
				++totalActive;
			}
		}

		for (int i = 0; i < activityIndicators.Length; i++) {
			if (i < activePlayers.Count && activePlayers [i]) {
				activityIndicators [i].color = activityColor;
			} else {
				activityIndicators [i].color = Color.gray;
			}
		}

		if (funkyPlayers.Count == 0) {
			return;
		}
			
		float distance = 0;
		int numDistances = 0;
		for (int n = 0; n < funkyPlayers.Count; n++) {
			if (activePlayers [n]) {
				for (int m = 0; m < n; m++) {
					if (activePlayers [m]) {
						distance += (funkyPlayers [n].transform.position - funkyPlayers [m].transform.position).magnitude;
						numDistances += 1;
					}
				}
			}
		}

		float funkIncrement = 100;
		if (numDistances > 0) {
			float avgDistance = distance / numDistances;
			funkIncrement += (maxDistance - avgDistance) * totalActive;
		}

		funkMeter += Time.deltaTime * funkIncrement;

		if (funkMeter >= maxFunk) {
			SceneManager.LoadScene ("Game");
		}
	}

	void OnGUI() {
		fillerBar.fillAmount = funkMeter/maxFunk;
	}
}
