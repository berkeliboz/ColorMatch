using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.Advertisements;

public class unlimitedModeGameManager : MonoBehaviour
{

    public GameObject unlimitedModeColorArrayReference;
    public Image[] level1Images = new Image[4];
    public Image[] level2Images = new Image[6];
    public Image[] level3Images = new Image[9];
    public Image[] level4Images = new Image[12];

    public GameObject[] playerTokenImages = new GameObject[8];

    public GameObject pausePanel;
    public Image colorTimerSlider;
    public Text colorTimerTextOut;
    public Text colorTimerTextIn;

    public Text userPtsText;
    public Text userPtsTextShadow;

    public int playerTokens = 4;

    public int foundState = 2;    // 0 FALSE
                                  // 1 TRUE
                                  // 2 NOT SET

    public float colorTimer;
    public int currentLevel;
    public float colorTimerDynamicValue = 2.55f;

    public GameObject[] gamePanels = new GameObject[4];

    public int playerPoints = 0;
    public bool gameActive = true;
    public int levelCounter = 0;

    public bool levelUp = false;
    public bool lvlDown = false;
    public bool shuffle = false;

    public int maxScore = 0;
    public int currentScore = 0;

    bool pointsAdded = false;


    public int tryCounter = 0;
    public Text oneMoreChance;
    private AudioSource audioSourceAccess;

    public Sound posSoundManager = new Sound();
    public Sound negSoundManager = new Sound();

    public float gameEndedTimer = 5f;


    void Awake()
    {
        foundState = 2;
        posSoundManager.source = gameObject.AddComponent<AudioSource>();
        posSoundManager.source.volume = 1f;
        negSoundManager.source = gameObject.AddComponent<AudioSource>();
        negSoundManager.source.volume = 1f;


    }



    void Start()
    {



        //Screen.SetResolution(480, 800, true);
        unlimitedModeColorArrayReference.GetComponent<unlimitedModeColorArray>().resetColors();


        for (int i = 0; i < gamePanels.Length ; i++) {
            gamePanels[i].SetActive(false);
        }
        pausePanel.SetActive(false);

        gameEndedTimer = 5f;


        levelManager(currentLevel);
        gamePanels[currentLevel - 1].SetActive(true);

        Debug.Log(currentLevel);

        colorTimer = 2.55f;
        colorTimerDynamicValue = 2.55f;
        playerPoints = 0;
        currentLevel = 1;
        pointsAdded = false;


        if (PlayerPrefs.HasKey("maxScore")) //   GetInt("maxScore") /*!= null*/)
            maxScore = PlayerPrefs.GetInt("maxScore");
        else
            maxScore = 0;

        if (PlayerPrefs.HasKey("maxScore"))//GetInt("currentCP") != null)
            currentScore = PlayerPrefs.GetInt("currentCP");
        else
            currentScore = 0;

        if (PlayerPrefs.HasKey("maxScore"))//GetInt("coinCounter") == null)
            tryCounter = PlayerPrefs.GetInt("coinCounter");
        else
            tryCounter = 0;

        for (int i = 0; i < 4; i++)
            playerTokenImages[i].SetActive(true);


        for (int i = 4; i < 8; i++)
            playerTokenImages[i].SetActive(false);

        for (int i = 4; i < 4 + tryCounter; i++) {
            playerTokenImages[i].SetActive(true);
        }


        oneMoreChance.text = "ONE MORE \n CHANCE \n" + tryCounter + " remaining";

        

    }

    // Update is called once per frame
    void Update()
    {

        if (gameActive)
        {
            screenActivator(currentLevel);
            pausePanel.SetActive(false);

            colorTimer -= Time.deltaTime;
            colorTimerSlider.fillAmount = colorTimer / colorTimerDynamicValue;
            colorTimerTextIn.text = colorTimer.ToString("F1");
            colorTimerTextOut.text = colorTimer.ToString("F1");

            userPtsText.text = playerPoints.ToString();
            userPtsTextShadow.text = playerPoints.ToString();

            Debug.Log(colorTimerDynamicValue);

            if ((foundState == 0 || colorTimer <= 0)) //FALSE CASE
            {

                levelDown();

                playNegative();

                foundState = 2;

                colorTimer = colorTimerDynamicValue;
                levelManager(currentLevel);
                if (colorTimer <= 0.45 || playerTokens <= 0)
                {
                    pointsAdded = false;
                    gameActive = false;
                }

            }


            else if (foundState == 1)
            {
                playPositive();

                foundMatch(currentLevel);
                foundState = 2;
                levelManager(currentLevel);
                colorTimer = colorTimerDynamicValue;
            }






        }
        else if (!gameActive)
        {

            gameEndedTimer -= 1 * Time.deltaTime;

            if (gameEndedTimer <= 0)
            {
                //Advertisement.Show("video");

            }


            for (int i = 0; i < 4; i++)
                gamePanels[i].SetActive(false);

            if(gameEndedTimer <= 4.5f)
                pausePanel.SetActive(true);
            currentLevel = 1;
            if (!pointsAdded)
            {
                currentScore += playerPoints;
                pointsAdded = true;
            }

            
            PlayerPrefs.SetInt("currentCP", currentScore);
            if (playerPoints > maxScore)
                PlayerPrefs.SetInt("maxScore", playerPoints);
        }

        

    }

    public void playPositive()
    {
        int randClip = Random.Range(0, 8);
        posSoundManager.source.clip = posSoundManager.clip[randClip];
        posSoundManager.source.Play();


    }
    
    public void playNegative()
    {
        int randClip = Random.Range(0, 7);
        negSoundManager.source.clip = negSoundManager.clip[randClip];
        negSoundManager.source.Play();
    }
    
    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);

    }


    public void replayGame()
    {
        Start();
        gameActive = true;
        playerTokens = 4 + tryCounter;
        levelCounter = 0;
        colorTimerDynamicValue = 2.55f;
    }

    public void playAds()
    {
        Advertisement.Show("rewardedVideo");
        int tCurrentLevel = currentLevel;//currentLevel
        int tCurrentScore = currentScore;
        replayGame();
        playerTokens = 1;
        currentLevel = tCurrentLevel;
        currentScore = tCurrentScore;
        colorTimer = colorTimerDynamicValue;




        return;
    }

    public void levelDown()
    {

        //soundCounter = 0;


        if (currentLevel != 1)
            currentLevel -= 1;

        playerTokens -= 1;

        playerTokenImages[playerTokens].SetActive(false);

        if (currentLevel == 1)
            colorTimerDynamicValue = (colorTimerDynamicValue * 85) / 100;
        unlimitedModeColorArrayReference.GetComponent<unlimitedModeColorArray>().resetColors();

    }

    public bool enoughPtsEarned()
    {
        switch (currentLevel)
        {
            case 1:
                if (levelCounter >= 15)
                {
                    levelCounter = 0;
                    currentLevel = 2;
                    return true;
                }
                else
                    return false;
            case 2:
                if (levelCounter >= 15)
                {
                    levelCounter = 0;
                    currentLevel = 3;
                    return true;
                }
                else
                    return false;
            case 3:
                if (levelCounter >= 15)
                {
                    levelCounter = 0;
                    currentLevel = 4;
                    return true;
                }
                else
                    return false;
        }
        return false;
    }

    public void foundMatch(int currentLevel)
    {

        levelCounter += 1;
        int multiplier = 1;
        if (currentLevel == 1)
            multiplier = 1;
        if (currentLevel == 2)
            multiplier = 25;
        if (currentLevel == 3)
            multiplier = 225;
        if (currentLevel == 4)
            multiplier = 1000;


        playerPoints += multiplier;
        if (currentLevel != 4 && enoughPtsEarned())
        {
            gamePanels[currentLevel - 1].SetActive(false);
            gamePanels[currentLevel].SetActive(true);

        }

    }

    public void screenActivator(int screenNumber)
    {
        for (int i = 0; i < 4; i++)
            gamePanels[i].SetActive(false);
        pausePanel.SetActive(false);

        if (screenNumber <= 3 || screenNumber >= 0)
            gamePanels[screenNumber - 1].SetActive(true);

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
                Debug.Log(colorNum);
                break;
        }
        Debug.Log("color manager returned default image");
        return myColor0;

    }

    public bool checkIfUnique(int[] array, int checkUntil)
    {
        for (int i = 0; i < checkUntil; i++)
            for (int j = i - 1; j > -1; j--)
                if (array[i] == array[j])
                    return false;
        return true;
    }

    public void levelManager(int screenNumber)
    {


        int arraySize = 0;

        if (screenNumber == 1)
            arraySize = 4;
        else if (screenNumber == 2)
            arraySize = 6;
        else if (screenNumber == 3)
            arraySize = 9;
        else if (screenNumber == 4)
            arraySize = 12;

        int[] colorArray = new int[arraySize];

        int colorSize = (screenNumber == 4) ? arraySize + 1 : arraySize + 3;


        for (int i = 0; i < arraySize; i++)
        {
            colorArray[i] = Random.Range(1, colorSize);

            if (i != 0)
                while (checkIfUnique(colorArray, i + 1) == false)
                    colorArray[i] = Random.Range(1, colorSize);
        }

        int randVal1 = Random.Range(0, arraySize);
        int randVal2 = Random.Range(0, arraySize);

        while (randVal1 == randVal2)
            randVal2 = Random.Range(0, arraySize);

        colorArray[randVal1] = colorArray[randVal2];


        for (int i = 0; i < arraySize; i++)
        {
            if (screenNumber == 1)
                level1Images[i].color = colorManager(colorArray[i]);
            else if (screenNumber == 2)
                level2Images[i].color = colorManager(colorArray[i]);
            else if (screenNumber == 3)
                level3Images[i].color = colorManager(colorArray[i]);
            else if (screenNumber == 4)
                level4Images[i].color = colorManager(colorArray[i]);
        }
    }


}
