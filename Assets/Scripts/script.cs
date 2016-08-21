using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class script : MonoBehaviour {

    public float timeRemaining = 4f;
    // Use this for initialization
    void Start () {
        InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
    }



    // Update is called once per frame
    void Update () {
        if (timeRemaining == 0)
        {
            SceneManager.LoadScene("Scenes/menu");
        }
    }

    void decreaseTimeRemaining()
    {
        timeRemaining--;
    }
}