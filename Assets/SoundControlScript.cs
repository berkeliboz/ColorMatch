using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControlScript : MonoBehaviour {

    
    void Start() {
        

    }

    void changeActive() {
        try
        {     
            
            AudioSource looperRef = GameObject.Find("Looper").GetComponent<AudioSource>();
            looperRef.mute = !looperRef.mute;
            if (transform.GetChild(1).gameObject.activeSelf)
                transform.GetChild(1).gameObject.SetActive(false);
            else
                transform.GetChild(1).gameObject.SetActive(true);

        }
        catch
        {
            Debug.Log("Couldn't access AudioSource");
        }

        

        return;
    }

	
    
	
	
}
