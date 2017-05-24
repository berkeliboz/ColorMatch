using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{


    public float gameTime = 100f;
    public Slider slider;
    public Text gameTimeText;

    public int screenNumber = 0;

    public Image lvl1Image1;
    public Image lvl1Image2;
    public Image lvl1Image3;
    public Image lvl1Image4;
    public Image lvl2Image1;
    public Image lvl2Image2;
    public Image lvl2Image3;
    public Image lvl2Image4;
    public Image lvl2Image5;
    public Image lvl2Image6;
    public Image lvl2Image7;
    public Image lvl1Image8;
    public Image lvl3Image1;
    public Image lvl3Image2;
    public Image lvl3Image3;
    public Image lvl3Image4;
    public Image lvl3Image5;
    public Image lvl3Image6;
    public Image lvl3Image7;
    public Image lvl3Image8;
    public Image lvl3Image9;
    public Image lvl4Image1;
    public Image lvl4Image2;
    public Image lvl4Image3;
    public Image lvl4Image4;
    public Image lvl4Image5;
    public Image lvl4Image6;
    public Image lvl4Image7;
    public Image lvl4Image8;
    public Image lvl4Image9;
    public Image lvl4Image10;
    public Image lvl4Image11;
    public Image lvl4Image12;


    public float colorTimer = 0.1f;

    public Color32[] colorArray = new Color32[2];


    public bool found = false;

    public Text userPointsText;
    public int userPoints = 0;


    // Use this for initialization
    void Start()
    {
        slider.value = gameTime;
        screenNumber += 1;
        gameTimeText.text = "Time = " + Mathf.CeilToInt(gameTime).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        colorTimer -= Time.deltaTime;
        slider.value = gameTime;
        screenManager(screenNumber);
        gameTimeText.text = "Time = " + Mathf.CeilToInt(gameTime).ToString();

        userPointsText.text = userPoints.ToString();


    }

    public Image getLvl1Image(int imageNum)
    {
        switch (imageNum)
        {
            case 1:
                return lvl1Image1;
            case 2:
                return lvl1Image2;
            case 3:
                return lvl1Image3;
            case 4:
                return lvl1Image4;
            default:
                Debug.Log("ERROR");
                break;
        }
        Debug.Log("getLvl1Image returned default image");
        return lvl1Image1;

    }

    public Color32 colorManager(int colorNum){

        Color32 myColor0 = new Color32(19, 149, 186, 255); //Light Blue
        Color32 myColor1 = new Color32(15, 91, 120, 255); //Medium Dark Blue
        Color32 myColor2 = new Color32(192, 46, 29, 255); //RED
        Color32 myColor3 = new Color32(241, 108, 32, 255); //Medium Orange
        Color32 myColor4 = new Color32(162, 184, 108, 255); //Light Green
        Color32 myColor5 = new Color32(235, 200, 68, 255); //Yellow
        
        switch (colorNum){
            case 1:
                return myColor0;
            case 2:
                return myColor1;
            case 3:
                return myColor2;
            case 4:
                return myColor3;
            case 5:
                return myColor4;
            case 6:
                return myColor5;

            default:
                Debug.Log("ERROR");
                break;
        }
        Debug.Log("color manager returned default image");
        return myColor0;

    }


    public void screenManager(int screenNum){
        switch (screenNum){
            case 1:
                level1Manager();
                break;
        }
    }

    public void level1Manager(){
        int randLvl1Image1;
        int randLvl1Image2;
        int randLvl1Image3;
        int randLvl1Image4;

        int randImageNum1;
        int randImageNum2;


        if (colorTimer <= 0 || found == true)
        {
            randLvl1Image1 = Random.Range(1, 7);
            randLvl1Image2 = Random.Range(1, 7);
            randLvl1Image3 = Random.Range(1, 7);
            randLvl1Image4 = Random.Range(1, 7);


            while (randLvl1Image2 == randLvl1Image1){
                randLvl1Image2 = Random.Range(1, 7);
            }
            while (randLvl1Image3 == randLvl1Image1 || randLvl1Image3 == randLvl1Image2){
                randLvl1Image3 = Random.Range(1, 7);
            }
            while (randLvl1Image4 == randLvl1Image1 || randLvl1Image4 == randLvl1Image2 || randLvl1Image4 == randLvl1Image3)
            {
                randLvl1Image4 = Random.Range(1, 7);
            }

            randImageNum1 = Random.Range(1, 5);
            randImageNum2 = Random.Range(1, 5);

            while (randImageNum1 == randImageNum2)
            {
                randImageNum2 = Random.Range(1, 5);
            }

            lvl1Image1.color = colorManager(randLvl1Image1);
            lvl1Image2.color = colorManager(randLvl1Image2);
            lvl1Image3.color = colorManager(randLvl1Image3);
            lvl1Image4.color = colorManager(randLvl1Image4);

            Color32 temp = getLvl1Image(randImageNum1).color;
            getLvl1Image(randImageNum2).color = temp;

            //Debug.Log(lvl1Image1.color);
            //Debug.Log(lvl1Image2.color);
            //Debug.Log(lvl1Image3.color);
            //Debug.Log(lvl1Image4.color);
            

            colorTimer = 3f;
        }
    }
        
    
}
