using UnityEngine;
using System.Collections;

public class SongSwitcher : MonoBehaviour {
	[SerializeField] AudioSource WaltsSong;
	[SerializeField] AudioSource FunkSong;

	// Use this for initialization
	void Start () {
		WaltsSong.Play();
		FunkSong.Play();
		FunkSong.mute = true;

		FunkyControl.OnFunkStarted += PlayFunk;
		FunkyControl.OnFunkStopped += PlayWalts;
	}

	void PlayFunk(GameObject player) {
		WaltsSong.mute = true;
		FunkSong.mute = false;
	}

	void PlayWalts(GameObject Player) {
		WaltsSong.mute = false;
		FunkSong.mute = true;
	}
}
