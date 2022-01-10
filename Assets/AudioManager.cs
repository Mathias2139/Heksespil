using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public int musicVolume;
    public int sFXVolume;
    public int voiceVolume;
    public int[] volumeSteps;
    public AudioClip[] randomSFX;
    public AudioSource sFXPlayer;
    public AudioClip[] randomVoice;
    public AudioSource voicePlayer;


    public void Start()
    {
        mixer.SetFloat("Music", volumeSteps[musicVolume]);
        mixer.SetFloat("SFX", volumeSteps[sFXVolume]);
        mixer.SetFloat("Voice", volumeSteps[voiceVolume]);
    }
    public void ChangeVolume(string target, int change)
    {
        switch (target)
        {
            case ("Music"):
                musicVolume = Mathf.Clamp(musicVolume + change,0,volumeSteps.Length);
                break;
            case ("SFX"):
                sFXVolume = Mathf.Clamp(sFXVolume + change, 0, volumeSteps.Length);
                sFXPlayer.clip = randomSFX[UnityEngine.Random.Range(0, randomSFX.Length)];
                sFXPlayer.Play();
                break;
            case ("Voice"):
                voiceVolume = Mathf.Clamp(voiceVolume + change, 0, volumeSteps.Length);
                voicePlayer.clip = randomVoice[UnityEngine.Random.Range(0, randomVoice.Length)];
                voicePlayer.Play();
                break;
        }
        mixer.SetFloat("Music", volumeSteps[musicVolume]);
        mixer.SetFloat("SFX", volumeSteps[sFXVolume]);
        mixer.SetFloat("Voice", volumeSteps[voiceVolume]);
    }

    
}
