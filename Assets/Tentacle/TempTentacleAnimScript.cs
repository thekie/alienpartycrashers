using UnityEngine;
using System.Collections;

public class TempTentacleAnimScript : MonoBehaviour {

    public Animator anim;

    private bool isFunking = false;
    private float funkTimer = 0.0f;
    public float funkCooldownTime = 0.5f;
	public Light pointLight;
    public Color playerDefaultColor;
    public Color maskDefaultColor;
    public Gradient rainbowGradient;

    public Material playerMaterial;
    public Material maskMaterial;

    public GameObject funkParticles;
	public GameObject cube;
    public GameObject mask;

	void Start() {
        playerMaterial = cube.GetComponent<Renderer> ().material;
        maskMaterial = mask.GetComponent<Renderer> ().material;
        maskDefaultColor = maskMaterial.color;
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

            playerMaterial.color = rainbowGradient.Evaluate(Time.time % 1);
            maskMaterial.color = rainbowGradient.Evaluate(Time.time % 1);
			pointLight.color = rainbowGradient.Evaluate(Time.time % 1);

	        if(funkTimer < 0f){
				funkTimer = funkCooldownTime;
				anim.SetTrigger ("dance" + Random.Range (6, 12));
	        } else {
	            funkTimer -= Time.deltaTime;
	        }
		}
	}

    public void DoFunkyColors(bool shouldDoFunkyColors){
        if(shouldDoFunkyColors){
            
            funkParticles.SetActive(true);
			isFunking = true;
			pointLight.intensity = 3;
        }
        else
        {
            playerMaterial.color = playerDefaultColor;
            maskMaterial.color = maskDefaultColor;
            funkParticles.SetActive(false);
			isFunking = false;
			pointLight.intensity = 0;
        }
    }
}
