using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicFadeOut : MonoBehaviour
{
    private AudioSource source;
    private float volume = 0.5f;
    public float fadeAmount = 0.01f;
    void Start()
    {
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        source.volume = Mathf.Lerp(source.volume, volume, fadeAmount);
    }
    public void FadeOut()
    {
        volume = 0;
    }
}
