using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class tutorialScreenScript : MonoBehaviour
{

    public Image[] imageArray = new Image[4];
    public GameObject[] colorBoxArray = new GameObject[4];
    public GameObject typeWriterDecoy;
    tutorialTypeWriter typeWriterReference;

    Color32 myColor = new Color32(235, 200, 68, 255); //Yellow
    Color32 myColor1 = new Color32(15, 91, 120, 255); //Medium Dark Blue
    Color32 myColor7 = new Color32(253, 76, 100, 255); //Pink
    Color32 myColor2 = new Color32(192, 46, 29, 255); //Red


    public List<Color> objectTagList = new List<Color>();
    public List<string> objectNameList = new List<string>();


    bool tutorialRead = false;
    bool clearFirst = false;
    int dialougeCounter = 2;
    public int counter = 2;
    public float transitionTimeCounter = 1.5f;

    public GameObject colorsPanel;

    void Start()
    {
        typeWriterReference = typeWriterDecoy.GetComponent<tutorialTypeWriter>();
        counter = 2;
        typeWriterReference.callTyper(1);
        dialougeCounter = 2;
        clearFirst = false;
        colorsPanel.SetActive(false);
    }

    void Update()
    {
        Debug.Log(dialougeCounter);

        if (objectTagList.Count == 2)
        {
            if ((objectTagList[0] == objectTagList[1]) && (objectNameList[0] != objectNameList[1]))
            {
                counter -= 1;
                objectNameList.Clear();
                objectTagList.Clear();
                clearFirst = true;
            } 

            if (dialougeCounter == 5 && clearFirst)
            {
                typeWriterReference.callTyper(dialougeCounter);
                buildTutorial();
                dialougeCounter += 1;

            }

            if (dialougeCounter >= 6)
            {
                typeWriterReference.callTyper(dialougeCounter);
                PlayerPrefs.SetInt("isTutorialDone", 1);
            }

        }

        if ((objectTagList.Count == 0) && counter <= 0)
            transitionTimeCounter -= Time.deltaTime;

        if (objectTagList.Count == 1)
        {
            if (dialougeCounter == 4)
            {
                dialougeCounter += 1;
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
        if(counter == 0)
            colorsPanel.SetActive(false);

        if(transitionTimeCounter <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }



    void buildTutorial()
    {
        Color32 currentImage = (counter == 2) ? myColor : myColor2;

        imageArray[0].color = currentImage;
        imageArray[2].color = currentImage;
        imageArray[3].color = myColor7;
        imageArray[1].color = myColor1;

        if(counter == 2)
        {
            imageArray[1].color = myColor7;
            imageArray[3].color = myColor1;
        }

    }






    IEnumerator objectFadeOut(GameObject objectRef)
    {
        float speed = 0.1f;
        Image objImage = objectRef.GetComponent<Image>();
        for (int i = 0; i < 10; i++)
        {

            Color newAlpha = new Color(0, 0, 0, (objImage.color.a / 100) * 80);
            objImage.color = newAlpha;
            yield return new WaitForSeconds(speed);

        }
    }

    void deleteButtonComponent()
    {
        for (int i = 0; i < 4; i++) {
            Destroy(colorBoxArray[i].GetComponent<Button>());
        }
            
    }

}
