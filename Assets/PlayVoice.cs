using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoice : MonoBehaviour
{
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>(); 
    }

    public void PlayClip(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
