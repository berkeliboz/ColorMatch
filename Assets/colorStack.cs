﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class colorStack : MonoBehaviour {
    public Stack<Color32> colorMatch;
    public Color32[] detectedColors = new Color32[2];
    public int generalCounter = 0;

    public bool matchIsMade = false;

    public string[] detectedColorTags = new string[2];



    void Update()
    {
        if (generalCounter == 100)
            generalCounter = 0;


    }

}
