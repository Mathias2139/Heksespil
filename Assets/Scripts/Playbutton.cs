using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Playbutton : MonoBehaviour
{
    public string sceneNavn;
    public AudioSource swoosh;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        swoosh.Play();
        SceneManager.LoadScene(sceneNavn);
        Debug.Log("play");
    }
}
