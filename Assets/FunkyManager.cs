using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FunkyManager : MonoBehaviour {
	public float funkMeter;
	GameObject[] players;

	public AnimationCurve decreaseCurve;

	public float maxDistance = 30.0f;
	public float maxFunk = 900.0f;

	public Texture2D emptyBar;
	public Texture2D fullBar;

	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
		
	void Update () {
		funkMeter -= Mathf.Max (Time.deltaTime * decreaseCurve.Evaluate (funkMeter), 0);
		funkMeter = Mathf.Max (funkMeter, 0);

		Debug.Log ("Funk Meter: " + funkMeter);
		Debug.Log ("Funk Decrement: " + decreaseCurve.Evaluate (funkMeter));

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
			Debug.Log ("Average Dist: " + avgDistance);
			funkIncrement += (maxDistance - avgDistance) * funkyPlayers.Count;
		}

		funkMeter += Time.deltaTime * funkIncrement;

		if (funkMeter >= maxFunk) {
			SceneManager.LoadScene ("Game");
		}
			
		Debug.Log ("Max Funk: " + funkMeter/maxFunk);
		Debug.Log ("Funk Increment: " + funkIncrement);
	}

	void OnGUI() {
		int value = Mathf.Min (300, Mathf.RoundToInt(funkMeter/maxFunk * 300));
		GUI.DrawTexture (new Rect (10, 10, 300, 50), emptyBar);
		GUI.DrawTexture (new Rect (10, 10, value, 50), fullBar);
	}
}
