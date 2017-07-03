using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialOnImageClick : MonoBehaviour
{

    public GameObject tutorialHandlerReference;

    public void onImageClick()
    {
        var listReference = tutorialHandlerReference.GetComponent<tutorialScreenScript>().objectTagList;
        string objectString = this.gameObject.name.ToString();
        if (!listReference.Contains(objectString))
            listReference.Add(objectString);

        Debug.Log(objectString);


        if (listReference.Count == 2)
        {

            tutorialHandlerReference.GetComponent<tutorialScreenScript>().userPressed = true;
            listReference.Clear();
        }

    }


        
}
