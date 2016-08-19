using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    void loadGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonUp("Player1_Funk") || 
            Input.GetButtonUp("Player2_Funk") || 
            Input.GetButtonUp("Player3_Funk") || 
            Input.GetButtonUp("Player4_Funk"))
        {
            loadmain();
        }

        if (Input.GetButtonUp("Space"))
        {
            loadGame();
        }
    }


    public void loadmain()
    {
        GameObject imageobj = GameObject.Find("Image");
        Image[] images  = imageobj.GetComponentsInChildren<Image>();

        foreach (Image image in images)
        {
            //Reverse order to avoid returns in each line
            if (image.sprite.name == "05" || image.sprite.name == "finish" )
            {
                loadGame();
            }
            if (image.sprite.name == "04-04")
            {
                image.sprite = Resources.Load("05", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "04-03")
            {
                image.sprite = Resources.Load("04-04", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "04-02")
            {
                image.sprite = Resources.Load("04-03", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "04-01")
            {
                image.sprite = Resources.Load("04-02", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "03")
            {
                image.sprite = Resources.Load("04-01", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "02")
            {
                image.sprite = Resources.Load("03", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "01")
            {
                image.sprite = Resources.Load("02", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "splash")
            {
                image.sprite = Resources.Load("01", typeof(Sprite)) as Sprite;
            }

        }
    }
}
