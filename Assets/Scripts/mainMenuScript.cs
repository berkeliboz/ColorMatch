using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.Advertisements;


public class mainMenuScript : MonoBehaviour
{


    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;

    public Text leftT;
    public Text rightT;

    public Text userCurrentCP;
    public Text userMaxPts;

    public int isTutorialDone = 0;

    public GameObject tutorialHelpPanel;

    public float colorTimer;

    Color32 purpleColor = new Color32(85, 42, 104, 255); //Purple
    Color32 pinkColor = new Color32(253, 76, 100, 255); //Pink
    Color32 cyanColor = new Color32(92, 167, 147, 255); //Cyan
    Color32 blueColor_Dark = new Color32(15, 91, 120, 255); //Medium Dark Blue
    Color32 redColor = new Color32(192, 46, 29, 255); //RED
    Color32 orangeColor = new Color32(241, 108, 32, 255); //Medium Orange
    Color32 greenColor_Light = new Color32(162, 184, 108, 255); //Light Green
    Color32 yellowColor = new Color32(235, 200, 68, 255); //Yellow

    Color32 whiteColor = new Color32(255, 255, 255, 255);




    public Color32 getRandomColor()
    {
        int randomValue = Random.Range(1, 9);
        switch (randomValue)
        {
            case 1:
                return pinkColor;
            case 2:
                return cyanColor;
            case 3:
                return blueColor_Dark;
            case 4:
                return redColor;
            case 5:
                return orangeColor;
            case 6:
                return greenColor_Light;
            case 7:
                return yellowColor;
            case 8:
                return purpleColor;
            default:
                return whiteColor;
        }

    }

    // Use this for initialization
    void Start()
    {

        Advertisement.Initialize("1694475");

        Advertisement.Show("video");

        Debug.Log(Advertisement.IsReady());

        if (PlayerPrefs.HasKey("isTutorialDone"))
            isTutorialDone = PlayerPrefs.GetInt("isTutorialDone");

        tutorialHelpPanel.SetActive(false);
        colorTimer = 0f;
        //Screen.SetResolution(480, 800, true);

        if (PlayerPrefs.HasKey("maxScore"))
        {
            int userPts = PlayerPrefs.GetInt("maxScore");
            if (userPts > 100000000)
                userPts = 100000000;
            userMaxPts.text = "Record - " + userPts.ToString();
        }
        else
            userMaxPts.text = "Record - 0";


        if (PlayerPrefs.HasKey("currentCP"))
        {
            int userPts = PlayerPrefs.GetInt("currentCP");
            userCurrentCP.text = " - " + userPts.ToString();

            int currentCMP = 0;
            if (PlayerPrefs.HasKey("currentCPM"))
                currentCMP = PlayerPrefs.GetInt("currentCPM");

            if (userPts > 1000000000)
            {
                userPts -= 1000000000;
                currentCMP += 1;
                PlayerPrefs.SetInt("currentCP", userPts);
                PlayerPrefs.SetInt("currentCPM", currentCMP);
            }

            if(currentCMP > 0)
                userCurrentCP.text = " - " + currentCMP.ToString() + "M";


        }
        else
            userCurrentCP.text = " - 0";

    }



    // Update is called once per frame
    void Update()
    {
        colorTimer -= Time.deltaTime;

        if (colorTimer <= 0)
        {
            quadColorAnimationManager();
            colorTimer = 1f;
        }



    }



    void quadColorAnimationManager()
    {

        Color32 newColor1 = getRandomColor();
        Color32 newColor2 = getRandomColor();
        Color32 newColor3 = getRandomColor();
        Color32 newColor4 = getRandomColor();



        Image1.color = newColor1;
        Image2.color = newColor2;
        Image3.color = newColor3;
        Image4.color = newColor4;



        leftT.color = getRandomColor();
        rightT.color = getRandomColor();
        if (leftT.color.r == rightT.color.r)
            rightT.color = getRandomColor();
    }

    public void loadRedScene()
    {
        /*
        Debug.Log("Real Mode");
        bool isTutorialDone = false;

        if (PlayerPrefs.HasKey("chaosDone") &&
            PlayerPrefs.GetInt("chaosDone") == 1)
            isTutorialDone = true;
            
        Debug.Log(PlayerPrefs.GetInt("chaosDone"));
        */

        Debug.Log("sonsuz mod");

        //if (isTutorialDone == 1)
        SceneManager.LoadScene(2);
        //else
        //   SceneManager.LoadScene(3);


    }

    public void openTutorialPanel() {
        tutorialHelpPanel.SetActive(true);
    }

    public void closeTutorialUI()
    {
        tutorialHelpPanel.SetActive(false);

    }

    public void loadGreenScene()
    {
        SceneManager.LoadScene(1);
        //if (isTutorialDone == 1)
        //   
        //else
        //     SceneManager.LoadScene(3);
    }

    public void loadShop()
    {
        SceneManager.LoadScene(4);

    }



}
