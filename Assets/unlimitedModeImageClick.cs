using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlimitedModeImageClick : MonoBehaviour {

    public Color32 imageColor;

    public string objectName;

    public GameObject colorArrayReference;
    public GameObject gameManagerReference;



    public void imageSendData()
    {
        objectName = this.name;
        imageColor = this.GetComponent<Image>().color;

        colorArrayReference.GetComponent<unlimitedModeColorArray>().addColorToArray(imageColor);
        colorArrayReference.GetComponent<unlimitedModeColorArray>().nameString.Add(objectName);

        if (colorArrayReference.GetComponent<unlimitedModeColorArray>().isColorArrayFull()){
            
            bool state;
            state = colorArrayReference.GetComponent<unlimitedModeColorArray>().checkColorMatch();
            if (state)
                gameManagerReference.GetComponent<unlimitedModeGameManager>().foundState = 1;
            else
                gameManagerReference.GetComponent<unlimitedModeGameManager>().foundState = 0;

        }


    }

}
