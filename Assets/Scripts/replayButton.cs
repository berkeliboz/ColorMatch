using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replayButton : MonoBehaviour {

    public GameObject gameManagerReference;


    public void replayGame() {
        gameManagerReference.GetComponent<gameManager>().screenNumber = 1;
        gameManagerReference.GetComponent<gameManager>().gameTime = 100f;
        gameManagerReference.GetComponent<gameManager>().colorTimer = 3f;
        gameManagerReference.GetComponent<gameManager>().pausePanel.SetActive(false);

    }


}
