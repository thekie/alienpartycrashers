using UnityEngine;
using System.Collections;

public class RockingAnimator : MonoBehaviour {
	// 1.6 seconds
	// 3.18 seconds full cycle

	public TempTentacleAnimScript tentacleAnimator;
	[Range(0.0f, 20.0f)]
	public float cycleLength = 1.59f;
	private float startTime;
	private bool rockLeft;

	void Start () {
		startTime = Time.time;
		rockLeft = false;
	}

	void Update () {
		float delta = Time.time - startTime;
		if (delta > cycleLength) {
			startTime = startTime + cycleLength;
			if (rockLeft) {
				tentacleAnimator.anim.SetTrigger ("waltzLeft");
			} else {
				tentacleAnimator.anim.SetTrigger ("waltzRight");
			}
			rockLeft = !rockLeft;
		}
	}
}
