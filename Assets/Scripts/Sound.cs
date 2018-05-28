using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound {

    public string Name;
    public AudioClip[] clip = new AudioClip[9];

    public float volume;


    [HideInInspector]
    public AudioSource source;
}
