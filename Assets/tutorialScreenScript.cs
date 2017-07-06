using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tutorialScreenScript : MonoBehaviour
{

    public Image[] imageArray = new Image[4];
    public GameObject typeWriterDecoy;
    tutorialTypeWriter typeWriterReference;

    Color32 myColor = new Color32(235, 200, 68, 255); //Yellow
    Color32 myColor1 = new Color32(15, 91, 120, 255); //Medium Dark Blue
    Color32 myColor7 = new Color32(253, 76, 100, 255); //Pink
    Color32 myColor2 = new Color32(192, 46, 29, 255); //Red


    public List<Color> objectTagList = new List<Color>();
    public List<string> objectNameList = new List<string>();


    bool userPressed = false;
    bool tutorialRead = false;
    int dialougeCounter = 2;
    int counter = 2;

    public GameObject colorsPanel;

    void Start()
    {
        typeWriterReference = typeWriterDecoy.GetComponent<tutorialTypeWriter>();
        counter = 2;
        typeWriterReference.callTyper(1);
        dialougeCounter = 2;
        colorsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (objectTagList.Count == 2)
        {
            Debug.Log(dialougeCounter);
            if (objectTagList[0] == objectTagList[1])
            {
                counter -= 1;
                objectTagList.Clear();
            }
            if (dialougeCounter == 5)
            {
                typeWriterReference.callTyper(dialougeCounter);
                buildTutorial();
                dialougeCounter += 1;

            }

            if (dialougeCounter == 6)
            {
                typeWriterReference.callTyper(dialougeCounter);
            }

        }

        if (objectTagList.Count == 1)
        {
                if (dialougeCounter == 4)
                {
                dialougeCounter += 1;
                Debug.Log("4 geldi");
                typeWriterReference.callTyper(4);

                }
             
        }

        if ((Input.GetMouseButtonDown(0) || (Input.touchCount >= 1)) && !tutorialRead)
        {
            if (!typeWriterReference.isItTyping)
            {

                typeWriterReference.callTyper(dialougeCounter);
                dialougeCounter += 1;
            }
            else
                typeWriterReference.callTyper(dialougeCounter);
            if (dialougeCounter == 4)
            {
                buildTutorial();
                tutorialRead = true;
                colorsPanel.SetActive(true);
            }
        }


    }

    void buildTutorial()
    {
        int invImage1 = Random.Range(0, 4);
        int invImage2 = Random.Range(0, 4);

        Color32 currentImage = (counter == 2) ? myColor : myColor2;


        for (int i = 0; i < 4; i++)
        {
            imageArray[i].color = currentImage;

        }

        while (invImage1 == invImage2)
            invImage2 = Random.Range(0, 4);


        imageArray[invImage1].color = myColor7;
        imageArray[invImage2].color = myColor1;

         


    }



}
