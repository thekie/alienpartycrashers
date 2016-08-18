using UnityEngine;
using System.Collections;

public class TempTentacleAnimScript : MonoBehaviour {

    public Animator anim;

    private bool isFunking = false;
    private float funkTimer = 0.0f;
    public float funkCooldownTime = 0.5f;

    public Color playerDefaultColor;
    public Gradient rainbowGradient;

    public Material playerMaterial;

    public GameObject funkParticles;
	public GameObject cube;

	void Start() {
		playerMaterial = cube.GetComponent<Renderer> ().material;
		DoFunkyColors (false);
	}

	void Update () {
		/*
        if(Input.GetKeyUp(KeyCode.Q)){
            anim.SetTrigger("dance1");
            funkTimer = funkCooldownTime;
        }

        if(Input.GetKeyUp(KeyCode.W)){
            anim.SetTrigger("dance2");
            funkTimer = funkCooldownTime;
        }

        if(Input.GetKeyUp(KeyCode.E)){
            anim.SetTrigger("dance3");
            funkTimer = funkCooldownTime;
        }

        if(Input.GetKeyUp(KeyCode.R)){
            anim.SetTrigger("dance4");
            funkTimer = funkCooldownTime;
        }

        if(Input.GetKeyUp(KeyCode.T)){
            anim.SetTrigger("dance5");
            funkTimer = funkCooldownTime;
        }

        if(Input.GetKeyUp(KeyCode.Y)){
            anim.SetTrigger("dance6");
            funkTimer = funkCooldownTime;
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            anim.SetTrigger("waltzLeft");
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)){
            anim.SetTrigger("waltzRight");
        }
        */

		if (isFunking) {
	        if(funkTimer < 0f){
				funkTimer = funkCooldownTime;
				anim.SetTrigger ("dance" + Random.Range (1, 6));
	        } else {
	            funkTimer -= Time.deltaTime;
	        }
		}
	}

    public void DoFunkyColors(bool shouldDoFunkyColors){
        if(shouldDoFunkyColors){
            playerMaterial.color = rainbowGradient.Evaluate(Time.time % 1);
            funkParticles.SetActive(true);
			isFunking = true;
        }
        else
        {
            playerMaterial.color = playerDefaultColor;
            funkParticles.SetActive(false);
			isFunking = false;
        }
    }
}
