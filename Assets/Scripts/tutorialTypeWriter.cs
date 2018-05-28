using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class tutorialTypeWriter : MonoBehaviour {

    public float typeSpeed = 0.1f;
    public Text textField;
    string fullText = "";
    public bool isItTyping = false;



    public void callTyper(int dialogueNumber)
    {
        if (!isItTyping)
        {
            typeSpeed = 0.001f;
            StartCoroutine(typeStringOnScreen(dialogueNumber));
        }
            
    }


    IEnumerator typeStringOnScreen(int dialogueNumber)
    {
        isItTyping = true;
        
        if(textField.text != "")
            textField.text = "";
        fullText = getDialogueString(dialogueNumber);

        foreach(char t in fullText)
        {
            textField.text += t;
            yield return new WaitForSeconds(typeSpeed);
        }
        isItTyping = false;
    }

    public string getDialogueString(int dialogueNumber)
    {
        switch (dialogueNumber) { 
        case 1:
            return "Welcome to Game of Colors TH3_0N3";
        case 2:
            return "You need to match the same colors";
        case 3:
            return "Touch one of the yellow boxes ";
        case 4:
            return "Now touch the other yellow box ";
        case 5:
            return "Now do the same for red ones ";
        case 6:
            return "Weldone TH3_0N3!! \n You are ready now! ";
        default:
            return getDialogueString(dialogueNumber);
        }
    }



}
