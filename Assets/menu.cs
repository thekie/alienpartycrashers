using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    public void loadmain()
    {
        GameObject imageobj = GameObject.Find("Image");
        Image[] images  = imageobj.GetComponentsInChildren<Image>();

        foreach (Image image in images)
        {
            //Reverse order to avoid returns in each line
            if (image.sprite.name == "05")
            {
                SceneManager.LoadScene("PartyPooper");
            }
            if (image.sprite.name == "04-04")
            {
                image.sprite = AssetDatabase.LoadAssetAtPath("Assets/05.jpg", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "04-03")
            {
                image.sprite = AssetDatabase.LoadAssetAtPath("Assets/04-04.jpg", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "04-02")
            {
                image.sprite = AssetDatabase.LoadAssetAtPath("Assets/04-03.jpg", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "04-01")
            {
                image.sprite = AssetDatabase.LoadAssetAtPath("Assets/04-02.jpg", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "03")
            {
                image.sprite = AssetDatabase.LoadAssetAtPath("Assets/04-01.jpg", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "02")
            {
                image.sprite = AssetDatabase.LoadAssetAtPath("Assets/03.jpg", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "01")
            {
                image.sprite = AssetDatabase.LoadAssetAtPath("Assets/02.jpg", typeof(Sprite)) as Sprite;
            }
            if (image.sprite.name == "splash")
            {
                image.sprite = AssetDatabase.LoadAssetAtPath("Assets/01.jpg", typeof(Sprite)) as Sprite;
            }

        }
        //
    }
}
