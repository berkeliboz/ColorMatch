using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialOnImageClick : MonoBehaviour
{

    public GameObject tutorialHandlerReference;

    Color32 myColor2 = new Color32(192, 46, 29, 255); //Red
    Color32 myColor = new Color32(235, 200, 68, 255); //Yellow



    public void onImageClick()
    {
        Image thisImage = this.GetComponent<Image>();
        var colorListReference = tutorialHandlerReference.GetComponent<tutorialScreenScript>().objectTagList;
        var stringListReference = tutorialHandlerReference.GetComponent<tutorialScreenScript>().objectNameList;
        Color objectString = thisImage.color;
        string nameString = thisImage.name;
        Debug.Log(nameString);
        if (objectString == myColor || objectString == myColor2)
        {

            colorListReference.Add(objectString);
            stringListReference.Add(nameString);
        }
            
    }
}
