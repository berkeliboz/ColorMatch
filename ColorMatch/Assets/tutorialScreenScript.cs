using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tutorialScreenScript : MonoBehaviour
{

    public Image[] imageArray = new Image[4];


    Color32 myColor = new Color32(235, 200, 68, 255); //Yellow
    Color32 myColor2 = new Color32(192, 46, 29, 255); //Red

    public List<string> objectTagList = new List<string>();

    public bool userPressed = true;
    int counter = 2;

    void Start()
    {
        counter = 2;



    }

    // Update is called once per frame
    void Update()
    {


        if (userPressed & counter >= 1)
        {
            buildTutorial();
            Debug.Log("entered");
            userPressed = false;
        }


    }

    void buildTutorial()
    {
        int invImage1 = Random.Range(0, 4);
        int invImage2 = Random.Range(0, 4);

        Color32 currentImage = (counter == 2) ? myColor : myColor2;
        counter -= 1;
        Debug.Log(counter);


        for (int i = 0; i < 4; i++)
        {
            imageArray[i].color = currentImage;

        }



        while (invImage1 == invImage2)
            invImage2 = Random.Range(0, 4);

        Color32 zeroAlpha = imageArray[invImage1].color;
        zeroAlpha.a = 0;
        imageArray[invImage1].color = zeroAlpha;
        imageArray[invImage2].color = zeroAlpha;

    }
    


}
