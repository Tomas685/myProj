using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour

{

    public static SoundManagerScript instance;
    public AudioSource[] soundeffects;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }



    public void PlaySound(int sound_to_play)
    {
        soundeffects[sound_to_play].Stop();
        soundeffects[sound_to_play].Play();
    }
}