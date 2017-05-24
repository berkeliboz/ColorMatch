using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class onImageClick : MonoBehaviour
{


    public Color32 imageColor;

    public bool matchFound = false;
    public GameObject colorStackReference;
    public GameObject gameManagerReference;
    public int counter;

    public void imageSendData()
    {
        while (Input.touchCount == 2)
        {
            counter = colorStackReference.GetComponent<colorStack>().generalCounter;
            colorStackReference.GetComponent<colorStack>().generalCounter += 1;
            imageColor = this.gameObject.GetComponent<Image>().color;
        
            counter++;
            colorStackReference.GetComponent<colorStack>().detectedColors.SetValue(imageColor, counter%2);

        }
        

    }

    public void checkColorMatch()
    {

        if (Input.touchCount == 2)
        {
            Color32 color1;
            Color32 color2;

            color1 = colorStackReference.GetComponent<colorStack>().detectedColors[0];
            color2 = colorStackReference.GetComponent<colorStack>().detectedColors[1];
            if (color1.r == color2.r && color1.g == color2.g && color1.b == color2.b)
            {
                Debug.Log("match found!!");
                gameManagerReference.GetComponent<gameManager>().userPoints += 1;
                matchFound = true;
            }


        }

        else
            matchFound = false;
        
    }

}
