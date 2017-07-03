using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class onImageClick : MonoBehaviour
{


    public Color32 imageColor;

    public GameObject colorStackReference;
    public GameObject gameManagerReference;
    public int counter;
    public string imageTag;

    public int tempCount = 0;


    public void imageSendData()
    {
        if (Input.touchCount >= 1)
        {
            counter = colorStackReference.GetComponent<colorStack>().generalCounter;
            colorStackReference.GetComponent<colorStack>().generalCounter += 1;
            imageColor = this.gameObject.GetComponent<Image>().color;
            imageTag = this.gameObject.tag.ToString();

            colorStackReference.GetComponent<colorStack>().touchCounter += 1;

            colorStackReference.GetComponent<colorStack>().colorMatch.Push(imageColor);
            Debug.Log(colorStackReference.GetComponent<colorStack>().colorMatch.Peek());
            counter++;
            colorStackReference.GetComponent<colorStack>().detectedColors.SetValue(imageColor, counter % 2);
            colorStackReference.GetComponent<colorStack>().detectedColorTags[counter % 2] = imageTag;
        }

    }

    public void checkColorMatch()
    {

        if (Input.touchCount >= 1)
        {

            Color32 color1;
            Color32 color2;

            Color32 myColor0 = new Color32(0, 0, 0, 0);
            Color32 myColor1 = new Color32(1, 3, 3, 0);

            string tag1 = colorStackReference.GetComponent<colorStack>().detectedColorTags[0];
            string tag2 = colorStackReference.GetComponent<colorStack>().detectedColorTags[1];

            color1 = colorStackReference.GetComponent<colorStack>().detectedColors[0];
            color2 = colorStackReference.GetComponent<colorStack>().detectedColors[1];
            if (color1.r == color2.r && color1.g == color2.g && color1.b == color2.b && tag1 != tag2)
            {

                colorStackReference.GetComponent<colorStack>().matchIsMade = true;



                colorStackReference.GetComponent<colorStack>().detectedColors[0] = myColor0;
                colorStackReference.GetComponent<colorStack>().detectedColors[1] = myColor1;

                colorStackReference.GetComponent<colorStack>().detectedColorTags[0] = "a";
                colorStackReference.GetComponent<colorStack>().detectedColorTags[1] = "a";
            }




        }


        else
            colorStackReference.GetComponent<colorStack>().matchIsMade = false;


    }

}
