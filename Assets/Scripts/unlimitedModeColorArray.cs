using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlimitedModeColorArray : MonoBehaviour {

    public Color32[] colorArray = new Color32[2];
    public List<string> nameString = new List<string>();

    public bool isColorArrayFull()
    {
        if (!(colorArray[0].a == 0 && colorArray[0].r == 0 && colorArray[0].g == 0 && colorArray[0].b == 0) &&
            !(colorArray[1].a == 0 && colorArray[1].r == 0 && colorArray[1].g == 0 && colorArray[1].b == 0))
            return true;
        return false;
    }

    public void resetColors()
    {
        Color32 defaultColor = new Color32(0,0,0,0);
        colorArray[0] = defaultColor;
        colorArray[1] = defaultColor;
        nameString.Clear();
    }

    public bool checkColorMatch()
    {
        if (isColorArrayFull())
            if ((colorArray[0].a == colorArray[1].a && colorArray[0].r == colorArray[1].r &&
                colorArray[0].g == colorArray[1].g && colorArray[0].b == colorArray[1].b))
            {
                if (nameString[0] != nameString[1]) {

                    resetColors();
                    return true;
                }
            }
        resetColors();
        return false;
    }

    public bool addColorToArray(Color32 newColor)
    {
        if (!isColorArrayFull())
        {
            
            if ((colorArray[0].a == 0 && colorArray[0].r == 0 && colorArray[0].g == 0 && colorArray[0].b == 0))
            {
                
                colorArray[0] = newColor;
                return true;
            }
            else if (colorArray[1].a == 0 && colorArray[1].r == 0 && colorArray[1].g == 0 && colorArray[1].b == 0)
            {
                colorArray[1] = newColor;
                return true;
            }
            return false;
        }
        return false;
    }

}



