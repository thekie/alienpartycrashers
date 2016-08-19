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
	public Image fillerBar;

	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
		
	void Update () {
		funkMeter -= Mathf.Max (Time.deltaTime * decreaseCurve.Evaluate (funkMeter), 0);
		funkMeter = Mathf.Max (funkMeter, 0);

		List<GameObject> funkyPlayers = new List<GameObject> ();

		foreach (GameObject go in players) {
			FunkyControl funkyControl = go.GetComponent<FunkyControl> ();
			if (funkyControl.isFunky) {
				funkyPlayers.Add (funkyControl.gameObject);
			}
		}

		if (funkyPlayers.Count == 0) {
			return;
		}
			
		float distance = 0;
		int numDistances = 0;
		for (int n = 0; n < funkyPlayers.Count; n++) {
			for (int m = 0; m<n; m++) {
				distance += (funkyPlayers [n].transform.position - funkyPlayers [m].transform.position).magnitude;
				numDistances += 1;
			}
		}

		float funkIncrement = 100;
		if (numDistances > 0) {
			float avgDistance = distance / numDistances;
			funkIncrement += (maxDistance - avgDistance) * funkyPlayers.Count;
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
