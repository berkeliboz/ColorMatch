using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{



    private const float GAME_TIME = 100f;
    private const float COLOR_TIMER = 3f;

    public float gameTime = GAME_TIME;
    public Slider gameTimeSlider;


    public int screenNumber = 0;

    public bool chaosDone = false;

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

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;


    public float colorTimer = COLOR_TIMER;



    public bool found = false;



    public GameObject colorStackReference;
    public Image timerPanel;
    public Text timerPanelText;
    public Text timerPanelTextShadow;

    public GameObject pausePanel;
    public int lastScreenNumber;

    public bool playerFinishedThisMode = false;
    private AudioSource audioSourceAccess;
    public Sound[] positiveSounds = new Sound[3];
    int soundCounter = 0;
    
    void Awake()
    {
        foreach (Sound s in positiveSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            //s.source.clip = s.clip;

        }
    }
    
    void Start()
    {
        pausePanel.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
        //Screen.SetResolution(480, 800, true);
        screenNumber += 1;
        audioSourceAccess = gameObject.GetComponent<AudioSource>();


    }

    void Update()
    {
        if(screenNumber != 5)
        {
            gameTime -= Time.deltaTime;
            colorTimer -= Time.deltaTime;
            lastScreenNumber = screenNumber;

        }



        screenManager(screenNumber);
        gameTimeSlider.value = gameTime / 100;
        timerPanel.fillAmount = colorTimer / 3;
        timerPanelText.text = colorTimer.ToString("F1");
        timerPanelTextShadow.text = colorTimer.ToString("F1");
    }


    public void playSound()
    {
        int posNum = (soundCounter % 6);
        soundCounter += 1;
        if (posNum == 0 || posNum == 1)
            positiveSounds[0].source.Play();
        else if (posNum == 2 || posNum == 3)
            positiveSounds[1].source.Play();
        else
            positiveSounds[2].source.Play();

        if (soundCounter == 100)
            soundCounter = 0;



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


    public Image getLvl2Image(int imageNum)
    {
        switch (imageNum)
        {
            case 1:
                return lvl2Image1;
            case 2:
                return lvl2Image2;
            case 3:
                return lvl2Image3;
            case 4:
                return lvl2Image4;
            case 5:
                return lvl2Image5;
            case 6:
                return lvl2Image6;
            default:
                Debug.Log("ERROR");
                break;
        }
        Debug.Log("getLvl2Image returned default image");
        return lvl1Image1;

    }

    public Image getLvl3Image(int imageNum)
    {
        switch (imageNum)
        {
            case 1:
                return lvl3Image1;
            case 2:
                return lvl3Image2;
            case 3:
                return lvl3Image3;
            case 4:
                return lvl3Image4;
            case 5:
                return lvl3Image5;
            case 6:
                return lvl3Image6;
            case 7:
                return lvl3Image7;
            case 8:
                return lvl3Image8;
            case 9:
                return lvl3Image9;
            default:
                Debug.Log("ERROR");
                break;
        }
        Debug.Log("getLvl3Image returned default image");
        return lvl1Image1;

    }


    public Image getLvl4Image(int imageNum)
    {
        switch (imageNum)
        {
            case 1:
                return lvl4Image1;
            case 2:
                return lvl4Image2;
            case 3:
                return lvl4Image3;
            case 4:
                return lvl4Image4;
            case 5:
                return lvl4Image5;
            case 6:
                return lvl4Image6;
            case 7:
                return lvl4Image7;
            case 8:
                return lvl4Image8;
            case 9:
                return lvl4Image9;
            case 10:
                return lvl4Image10;
            case 11:
                return lvl4Image11;
            case 12:
                return lvl4Image12;
            default:
                Debug.Log("ERROR");
                break;
        }
        Debug.Log("getLvl3Image returned default image");
        return lvl1Image1;




    }



    public GameObject getPanel(int panelNumber)
    {
        switch (panelNumber)
        {
            case 1:
                return panel1;
            case 2:
                return panel2;
            case 3:
                return panel3;
            case 4:
                return panel4;
            default:
                Debug.Log("ERROR");
                return panel1;
        }
    }

    public Color32 colorManager(int colorNum)
    {

        Color32 myColor0 = new Color32(19, 149, 186, 255); //Light Blue
        Color32 myColor1 = new Color32(15, 91, 120, 255); //Medium Dark Blue
        Color32 myColor2 = new Color32(192, 46, 29, 255); //RED
        Color32 myColor3 = new Color32(241, 108, 32, 255); //Medium Orange
        Color32 myColor4 = new Color32(162, 184, 108, 255); //Light Green
        Color32 myColor5 = new Color32(235, 200, 68, 255); //Yellow
        Color32 myColor6 = new Color32(85, 42, 104, 255); //Purple
        Color32 myColor7 = new Color32(253, 76, 100, 255); //Pink
        Color32 myColor8 = new Color32(92, 167, 147, 255); //Cyan
        Color32 myColor9 = new Color32(239, 139, 44, 255); //Light Orange
        Color32 myColor10 = new Color32(236, 170, 56, 255); //Dark Yellow
        Color32 myColor11 = new Color32(0, 95, 0, 255); //Dark Green

        switch (colorNum)
        {
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
            case 7:
                return myColor6;
            case 8:
                return myColor7;
            case 9:
                return myColor8;
            case 10:
                return myColor9;
            case 11:
                return myColor10;
            case 12:
                return myColor11;

            default:
                Debug.Log("ERROR");
                break;
        }
        Debug.Log("color manager returned default image");
        return myColor0;

    }

    public void screenManager(int screenNum)
    {
        switch (screenNum)
        {
            case 1:
                panel1.SetActive(true);
                level1Manager();
                break;
            case 2:
                panel2.SetActive(true);
                level2Manager();
                break;
            case 3:
                panel3.SetActive(true);
                level3Manager();
                break;
            case 4:
                playerFinishedThisMode = true;
                panel4.SetActive(true);
                level4Manager();
                break;
            case 5:
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(false);
                pausePanel.SetActive(true);

                colorTimer = 0;
                break;
        }
    }

    public void level1Manager()
    {
        int randLvl1Image1;
        int randLvl1Image2;
        int randLvl1Image3;
        int randLvl1Image4;

        int randImageNum1;
        int randImageNum2;

        found = colorStackReference.GetComponent<colorStack>().matchIsMade;



        if (found == true)
        {
            playSound();

            gameTime -= colorTimer;

            randLvl1Image1 = Random.Range(1, 7);
            randLvl1Image2 = Random.Range(1, 7);
            randLvl1Image3 = Random.Range(1, 7);
            randLvl1Image4 = Random.Range(1, 7);


            while (randLvl1Image2 == randLvl1Image1)
            {
                randLvl1Image2 = Random.Range(1, 7);
            }
            while (randLvl1Image3 == randLvl1Image1 || randLvl1Image3 == randLvl1Image2)
            {
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


            colorStackReference.GetComponent<colorStack>().matchIsMade = false;

            colorTimer = 3f;
            if (gameTime <= 75f)    // Modifies next canvas
            {
                screenNumber = 2;
                panel1.SetActive(false);

                lvl2Image1.color = colorManager(randLvl1Image1);
                lvl2Image2.color = colorManager(randLvl1Image2);
                lvl2Image3.color = colorManager(randLvl1Image3);
                lvl2Image4.color = colorManager(randLvl1Image4);
                lvl2Image5.color = colorManager(9);
                lvl2Image6.color = colorManager(10);

                randImageNum1 = Random.Range(1, 7);
                randImageNum2 = Random.Range(1, 7);

                while (randImageNum1 == randImageNum2)
                {
                    randImageNum2 = Random.Range(1, 7);
                }
                temp = getLvl2Image(randImageNum1).color;
                getLvl2Image(randImageNum2).color = temp;


                return;
            }

        }
        if (colorTimer <= 0)
            screenNumber = 5; 

    }


    public void level2Manager()
    {
        int randLvl2Image1;
        int randLvl2Image2;
        int randLvl2Image3;
        int randLvl2Image4;
        int randLvl2Image5;
        int randLvl2Image6;


        int randImageNum1;
        int randImageNum2;

        found = colorStackReference.GetComponent<colorStack>().matchIsMade;

        if (found == true)
        {
            playSound();
            randLvl2Image1 = Random.Range(1, 7);
            randLvl2Image2 = Random.Range(1, 7);
            randLvl2Image3 = Random.Range(1, 7);
            randLvl2Image4 = Random.Range(1, 7);
            randLvl2Image5 = Random.Range(1, 7);
            randLvl2Image6 = Random.Range(1, 7);



            while (randLvl2Image2 == randLvl2Image1)
            {
                randLvl2Image2 = Random.Range(1, 7);
            }
            while (randLvl2Image3 == randLvl2Image1 ||
                randLvl2Image3 == randLvl2Image2)
            {
                randLvl2Image3 = Random.Range(1, 7);
            }
            while (randLvl2Image4 == randLvl2Image1 ||
                randLvl2Image4 == randLvl2Image2 ||
                randLvl2Image4 == randLvl2Image3)
            {
                randLvl2Image4 = Random.Range(1, 7);
            }
            while (randLvl2Image5 == randLvl2Image1 ||
                randLvl2Image5 == randLvl2Image2 ||
                randLvl2Image5 == randLvl2Image3 ||
                randLvl2Image5 == randLvl2Image4)
            {
                randLvl2Image5 = Random.Range(1, 7);
            }
            while (randLvl2Image6 == randLvl2Image1 ||
                randLvl2Image6 == randLvl2Image2 ||
                randLvl2Image6 == randLvl2Image3 ||
                randLvl2Image6 == randLvl2Image4 ||
                randLvl2Image6 == randLvl2Image5)
            {
                randLvl2Image6 = Random.Range(1, 7);
            }

            randImageNum1 = Random.Range(1, 7);
            randImageNum2 = Random.Range(1, 7);


            while (randImageNum1 == randImageNum2)
            {
                randImageNum2 = Random.Range(1, 7);
            }

            lvl2Image1.color = colorManager(randLvl2Image1);
            lvl2Image2.color = colorManager(randLvl2Image2);
            lvl2Image3.color = colorManager(randLvl2Image3);
            lvl2Image4.color = colorManager(randLvl2Image4);
            lvl2Image5.color = colorManager(randLvl2Image5);
            lvl2Image6.color = colorManager(randLvl2Image6);

            Color32 temp = getLvl2Image(randImageNum1).color;
            getLvl2Image(randImageNum2).color = temp;


            colorStackReference.GetComponent<colorStack>().matchIsMade = false;


            colorTimer = 3f;

            if (gameTime < 50)
            {
                screenNumber = 3;
                panel2.SetActive(false);



                lvl3Image1.color = colorManager(randLvl2Image1);
                lvl3Image2.color = colorManager(randLvl2Image2);
                lvl3Image3.color = colorManager(randLvl2Image3);
                lvl3Image4.color = colorManager(randLvl2Image4);
                lvl3Image5.color = colorManager(randLvl2Image5);
                lvl3Image6.color = colorManager(randLvl2Image6);
                lvl3Image7.color = colorManager(10);
                lvl3Image8.color = colorManager(11);
                lvl3Image9.color = colorManager(12);
                randImageNum1 = Random.Range(1, 7);
                randImageNum2 = Random.Range(1, 7);

                while (randImageNum1 == randImageNum2)
                {
                    randImageNum2 = Random.Range(1, 10);
                }
                temp = getLvl3Image(randImageNum1).color;
                getLvl3Image(randImageNum2).color = temp;


                return;


            }

        }
        if (colorTimer <= 0)
            screenNumber = 5;
            

    }


    public void level3Manager()
    {
        playSound();
        if (!chaosDone)
        {
            chaosDone = true;
            PlayerPrefs.SetInt("chaosDone", 1);
        }
        int randLvl3Image1;
        int randLvl3Image2;
        int randLvl3Image3;
        int randLvl3Image4;
        int randLvl3Image5;
        int randLvl3Image6;
        int randLvl3Image7;
        int randLvl3Image8;
        int randLvl3Image9;

        int randImageNum1;
        int randImageNum2;

        found = colorStackReference.GetComponent<colorStack>().matchIsMade;

        if (found == true)
        {


            randLvl3Image1 = Random.Range(1, 10);
            randLvl3Image2 = Random.Range(1, 10);
            randLvl3Image3 = Random.Range(1, 10);
            randLvl3Image4 = Random.Range(1, 10);
            randLvl3Image5 = Random.Range(1, 10);
            randLvl3Image6 = Random.Range(1, 10);
            randLvl3Image7 = Random.Range(1, 10);
            randLvl3Image8 = Random.Range(1, 10);
            randLvl3Image9 = Random.Range(1, 10);



            while (randLvl3Image2 == randLvl3Image1)
            {
                randLvl3Image2 = Random.Range(1, 10);
            }
            while (randLvl3Image3 == randLvl3Image1 ||
                randLvl3Image3 == randLvl3Image2)
            {
                randLvl3Image3 = Random.Range(1, 10);
            }
            while (randLvl3Image4 == randLvl3Image1 ||
                randLvl3Image4 == randLvl3Image2 ||
                randLvl3Image4 == randLvl3Image3)
            {
                randLvl3Image4 = Random.Range(1, 10);
            }
            while (randLvl3Image5 == randLvl3Image1 ||
                randLvl3Image5 == randLvl3Image2 ||
                randLvl3Image5 == randLvl3Image3 ||
                randLvl3Image5 == randLvl3Image4)
            {
                randLvl3Image5 = Random.Range(1, 10);
            }
            while (randLvl3Image6 == randLvl3Image1 ||
                randLvl3Image6 == randLvl3Image2 ||
                randLvl3Image6 == randLvl3Image3 ||
                randLvl3Image6 == randLvl3Image4 ||
                randLvl3Image6 == randLvl3Image5)
            {
                randLvl3Image6 = Random.Range(1, 10);
            }
            while (randLvl3Image7 == randLvl3Image1 ||
                randLvl3Image7 == randLvl3Image2 ||
                randLvl3Image7 == randLvl3Image3 ||
                randLvl3Image7 == randLvl3Image4 ||
                randLvl3Image7 == randLvl3Image5 ||
                randLvl3Image7 == randLvl3Image6)
            {
                randLvl3Image7 = Random.Range(1, 10);
            }
            while (randLvl3Image8 == randLvl3Image1 ||
                randLvl3Image8 == randLvl3Image2 ||
                randLvl3Image8 == randLvl3Image3 ||
                randLvl3Image8 == randLvl3Image4 ||
                randLvl3Image8 == randLvl3Image5 ||
                randLvl3Image8 == randLvl3Image6 ||
                randLvl3Image8 == randLvl3Image7)
            {
                randLvl3Image8 = Random.Range(1, 10);
            }
            while (randLvl3Image9 == randLvl3Image1 ||
                randLvl3Image9 == randLvl3Image2 ||
                randLvl3Image9 == randLvl3Image3 ||
                randLvl3Image9 == randLvl3Image4 ||
                randLvl3Image9 == randLvl3Image5 ||
                randLvl3Image9 == randLvl3Image6 ||
                randLvl3Image9 == randLvl3Image7 ||
                randLvl3Image9 == randLvl3Image8)
            {
                randLvl3Image9 = Random.Range(1, 10);
            }



            randImageNum1 = Random.Range(1, 10);
            randImageNum2 = Random.Range(1, 10);


            while (randImageNum1 == randImageNum2)
            {
                randImageNum2 = Random.Range(1, 10);
            }

            lvl3Image1.color = colorManager(randLvl3Image1);
            lvl3Image2.color = colorManager(randLvl3Image2);
            lvl3Image3.color = colorManager(randLvl3Image3);
            lvl3Image4.color = colorManager(randLvl3Image4);
            lvl3Image5.color = colorManager(randLvl3Image5);
            lvl3Image6.color = colorManager(randLvl3Image6);
            lvl3Image7.color = colorManager(randLvl3Image7);
            lvl3Image8.color = colorManager(randLvl3Image8);
            lvl3Image9.color = colorManager(randLvl3Image9);


            Color32 temp = getLvl3Image(randImageNum1).color;
            getLvl3Image(randImageNum2).color = temp;



            colorStackReference.GetComponent<colorStack>().matchIsMade = false;


            colorTimer = 3f;
            if (gameTime <= 25)
            {

                screenNumber = 4;

                panel3.SetActive(false);


                lvl4Image1.color = colorManager(randLvl3Image1);
                lvl4Image2.color = colorManager(randLvl3Image2);
                lvl4Image3.color = colorManager(randLvl3Image3);
                lvl4Image4.color = colorManager(randLvl3Image4);
                lvl4Image5.color = colorManager(randLvl3Image5);
                lvl4Image6.color = colorManager(randLvl3Image6);
                lvl4Image7.color = colorManager(randLvl3Image7);
                lvl4Image8.color = colorManager(randLvl3Image8);
                lvl4Image9.color = colorManager(randLvl3Image9);
                lvl4Image10.color = colorManager(10);
                lvl4Image11.color = colorManager(11);
                lvl4Image12.color = colorManager(12);

                randImageNum1 = Random.Range(1, 10);
                randImageNum2 = Random.Range(1, 10);

                while (randImageNum1 == randImageNum2)
                {
                    randImageNum2 = Random.Range(1, 10);
                }
                temp = getLvl4Image(randImageNum1).color;
                getLvl4Image(randImageNum2).color = temp;


            }


        }
        if (colorTimer <= 0)
            screenNumber = 5;

    }

    public void level4Manager()
    {
        int randLvl4Image1;
        int randLvl4Image2;
        int randLvl4Image3;
        int randLvl4Image4;
        int randLvl4Image5;
        int randLvl4Image6;
        int randLvl4Image7;
        int randLvl4Image8;
        int randLvl4Image9;
        int randLvl4Image10;
        int randLvl4Image11;
        int randLvl4Image12;


        playSound();


        int randImageNum1;
        int randImageNum2;

        found = colorStackReference.GetComponent<colorStack>().matchIsMade;

        if (found == true)
        {


            randLvl4Image1 = Random.Range(1, 13);
            randLvl4Image2 = Random.Range(1, 13);
            randLvl4Image3 = Random.Range(1, 13);
            randLvl4Image4 = Random.Range(1, 13);
            randLvl4Image5 = Random.Range(1, 13);
            randLvl4Image6 = Random.Range(1, 13);
            randLvl4Image7 = Random.Range(1, 13);
            randLvl4Image8 = Random.Range(1, 13);
            randLvl4Image9 = Random.Range(1, 13);
            randLvl4Image10 = Random.Range(1, 13);
            randLvl4Image11 = Random.Range(1, 13);
            randLvl4Image12 = Random.Range(1, 13);


            while (randLvl4Image2 == randLvl4Image1)
            {
                randLvl4Image2 = Random.Range(1, 13);
            }
            while (randLvl4Image3 == randLvl4Image1 ||
                randLvl4Image3 == randLvl4Image2)
            {
                randLvl4Image3 = Random.Range(1, 13);
            }
            while (randLvl4Image4 == randLvl4Image1 ||
                randLvl4Image4 == randLvl4Image2 ||
                randLvl4Image4 == randLvl4Image3)
            {
                randLvl4Image4 = Random.Range(1, 13);
            }
            while (randLvl4Image5 == randLvl4Image1 ||
                randLvl4Image5 == randLvl4Image2 ||
                randLvl4Image5 == randLvl4Image3 ||
                randLvl4Image5 == randLvl4Image4)
            {
                randLvl4Image5 = Random.Range(1, 13);
            }
            while (randLvl4Image6 == randLvl4Image1 ||
                randLvl4Image6 == randLvl4Image2 ||
                randLvl4Image6 == randLvl4Image3 ||
                randLvl4Image6 == randLvl4Image4 ||
                randLvl4Image6 == randLvl4Image5)
            {
                randLvl4Image6 = Random.Range(1, 13);
            }
            while (randLvl4Image7 == randLvl4Image1 ||
                randLvl4Image7 == randLvl4Image2 ||
                randLvl4Image7 == randLvl4Image3 ||
                randLvl4Image7 == randLvl4Image4 ||
                randLvl4Image7 == randLvl4Image5 ||
                randLvl4Image7 == randLvl4Image6)
            {
                randLvl4Image7 = Random.Range(1, 13);
            }
            while (randLvl4Image8 == randLvl4Image1 ||
                randLvl4Image8 == randLvl4Image2 ||
                randLvl4Image8 == randLvl4Image3 ||
                randLvl4Image8 == randLvl4Image4 ||
                randLvl4Image8 == randLvl4Image5 ||
                randLvl4Image8 == randLvl4Image6 ||
                randLvl4Image8 == randLvl4Image7)
            {
                randLvl4Image8 = Random.Range(1, 13);
            }
            while (randLvl4Image9 == randLvl4Image1 ||
                randLvl4Image9 == randLvl4Image2 ||
                randLvl4Image9 == randLvl4Image3 ||
                randLvl4Image9 == randLvl4Image4 ||
                randLvl4Image9 == randLvl4Image5 ||
                randLvl4Image9 == randLvl4Image6 ||
                randLvl4Image9 == randLvl4Image7 ||
                randLvl4Image9 == randLvl4Image8)
            {
                randLvl4Image9 = Random.Range(1, 13);
            }

            while (randLvl4Image10 == randLvl4Image1 ||
                randLvl4Image10 == randLvl4Image2 ||
                randLvl4Image10 == randLvl4Image3 ||
                randLvl4Image10 == randLvl4Image4 ||
                randLvl4Image10 == randLvl4Image5 ||
                randLvl4Image10 == randLvl4Image6 ||
                randLvl4Image10 == randLvl4Image7 ||
                randLvl4Image10 == randLvl4Image8 ||
                randLvl4Image10 == randLvl4Image9)
            {
                randLvl4Image10 = Random.Range(1, 13);
            }
            while (randLvl4Image11 == randLvl4Image1 ||
                randLvl4Image11 == randLvl4Image2 ||
                randLvl4Image11 == randLvl4Image3 ||
                randLvl4Image11 == randLvl4Image4 ||
                randLvl4Image11 == randLvl4Image5 ||
                randLvl4Image11 == randLvl4Image6 ||
                randLvl4Image11 == randLvl4Image7 ||
                randLvl4Image11 == randLvl4Image8 ||
                randLvl4Image11 == randLvl4Image9 ||
                randLvl4Image11 == randLvl4Image10)
            {
                randLvl4Image11 = Random.Range(1, 13);
            }
            while (randLvl4Image12 == randLvl4Image1 ||
                randLvl4Image12 == randLvl4Image2 ||
                randLvl4Image12 == randLvl4Image3 ||
                randLvl4Image12 == randLvl4Image4 ||
                randLvl4Image12 == randLvl4Image5 ||
                randLvl4Image12 == randLvl4Image6 ||
                randLvl4Image12 == randLvl4Image7 ||
                randLvl4Image12 == randLvl4Image8 ||
                randLvl4Image12 == randLvl4Image9 ||
                randLvl4Image12 == randLvl4Image10 ||
                randLvl4Image12 == randLvl4Image11)
            {
                randLvl4Image12 = Random.Range(1, 13);
            }




            randImageNum1 = Random.Range(1, 13);
            randImageNum2 = Random.Range(1, 13);




            while (randImageNum1 == randImageNum2)
            {
                randImageNum2 = Random.Range(1, 13);
            }




            lvl4Image1.color = colorManager(randLvl4Image1);
            lvl4Image2.color = colorManager(randLvl4Image2);
            lvl4Image3.color = colorManager(randLvl4Image3);
            lvl4Image4.color = colorManager(randLvl4Image4);
            lvl4Image5.color = colorManager(randLvl4Image5);
            lvl4Image6.color = colorManager(randLvl4Image6);
            lvl4Image7.color = colorManager(randLvl4Image7);
            lvl4Image8.color = colorManager(randLvl4Image8);
            lvl4Image9.color = colorManager(randLvl4Image9);
            lvl4Image10.color = colorManager(randLvl4Image10);
            lvl4Image11.color = colorManager(randLvl4Image11);
            lvl4Image12.color = colorManager(randLvl4Image12);


            Color32 temp = getLvl4Image(randImageNum1).color;
            getLvl4Image(randImageNum2).color = temp;



            colorStackReference.GetComponent<colorStack>().matchIsMade = false;
            colorTimer = 3f;

            if(gameTime <= 0)
            {
                screenNumber = 5;


            }

        }
          if (colorTimer <= 0)
            screenNumber = 5;


    }
}