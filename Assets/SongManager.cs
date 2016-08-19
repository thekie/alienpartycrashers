using UnityEngine;
using System.Collections;

public class SongManager : MonoBehaviour {
	private static SongManager instance = null;
	public static SongManager Instance {
		get { return instance; }
	}

	[SerializeField] AudioSource WaltsSong;
	[SerializeField] AudioSource FunkSong;
	int funkCount = 0;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}

	void Update() {
		if(funkCount > 0) {
			PlayFunk();
		} else {
			PlayWalts();
		}
	}


	void Start () {
		WaltsSong.Play();
		FunkSong.Play();

		FunkyControl.OnFunkStarted += (GameObject gameObject) => {
			funkCount++;
		};

		FunkyControl.OnFunkStopped += (GameObject gameObject) => {
			funkCount--;
		};
	}

	void PlayFunk() {
		WaltsSong.mute = true;
		FunkSong.mute = false;
	}

	void PlayWalts() {
		WaltsSong.mute = false;
		FunkSong.mute = true;
	}
}
