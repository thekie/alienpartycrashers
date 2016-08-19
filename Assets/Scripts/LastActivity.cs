using UnityEngine;
using System.Collections;

public class LastActivity : MonoBehaviour {

	[HideInInspector]
	public float lastActivity = -1e4f;

	public void updateLastActivity() {
		lastActivity = Time.time;
	}
}
