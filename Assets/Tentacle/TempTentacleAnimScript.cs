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

	void Update () {

        if(funkTimer < 0.1f){
            isFunking = false;
            funkTimer = 0.0f;

            DoFunkyColors(false);
        }
        else
        {
            isFunking = true;
            funkTimer -= Time.deltaTime;

            DoFunkyColors(true);
        }


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
	}

    void DoFunkyColors(bool shouldDoFunkyColors){
        if(shouldDoFunkyColors){
            playerMaterial.color = rainbowGradient.Evaluate(Time.time % 1);
            funkParticles.SetActive(true);
        }
        else
        {
            playerMaterial.color = playerDefaultColor;
            funkParticles.SetActive(false);
        }
    }
}
