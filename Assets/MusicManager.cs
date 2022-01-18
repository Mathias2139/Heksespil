using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource source;
    private float audiolevel;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        source = GetComponent<AudioSource>();
        audiolevel = 0f;
    }
    private void Update()
    {
        if(audiolevel != source.volume)
        {
            source.volume = Mathf.Lerp(source.volume, audiolevel, 0.02f);
        }
    } 

    public void UpdateVolume(float newVolume)
    {
        audiolevel = newVolume;
    }
}
