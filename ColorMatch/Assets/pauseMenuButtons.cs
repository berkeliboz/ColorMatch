using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class pauseMenuButtons : MonoBehaviour {

    public GameObject gameManagerReference;

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void giveChance()
    {
        int lastLevelValue = gameManagerReference.GetComponent<gameManager>().lastScreenNumber;
        gameManagerReference.GetComponent<gameManager>().colorTimer = 3;
        gameManagerReference.GetComponent<gameManager>().screenNumber = lastLevelValue;
        gameManagerReference.GetComponent<gameManager>().pausePanel.SetActive(false);
    }

}
