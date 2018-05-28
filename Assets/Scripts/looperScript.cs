using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class looperScript : MonoBehaviour
{
    public GameObject soundMuteIcon;

    public AudioClip[] loops = new AudioClip[3];
    private AudioSource audioSourceAccess;

    public static looperScript instance;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);





        audioSourceAccess = gameObject.AddComponent<AudioSource>();
        audioSourceAccess.loop = true;
        audioSourceAccess.volume = 0.25f;
        assignLoop();
        audioSourceAccess.Play();

    }

    private void Awake()
    {
        if (soundMuteIcon == null) { };
            //gam
    }

    void assignLoop()
    {
        int rand = Random.Range(0, 3);
        audioSourceAccess.clip = loops[rand];

    }


    public void muteSound()
    {
        if (soundMuteIcon.activeInHierarchy) //UNMUTE
        {
            soundMuteIcon.SetActive(false);
            audioSourceAccess.GetComponent<AudioSource>().volume = 0.25f;


        }
        else {                              //MUTE
            soundMuteIcon.SetActive(true);
            audioSourceAccess.GetComponent<AudioSource>().volume = 0f;


        }

    }

}
