using UnityEngine;
using System.Collections;

public class TempUfoAnimScript : MonoBehaviour {
   
    public Animator ufoAnim;
	
    void PrepareDive(){
        ufoAnim.SetTrigger("prepareDive");
    }

    void SlamDown(){
        ufoAnim.SetTrigger("slamDown");
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Q)){
            PrepareDive();
        }

        if(Input.GetKeyUp(KeyCode.W)){
            SlamDown();
        }
	}
}
