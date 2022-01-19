using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Playbutton : MonoBehaviour
{
    public string sceneNavn;
    public Animator doorAnimation;
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
        doorAnimation.SetTrigger("Open");
        Invoke("Wait",0.3f);
        Debug.Log("play");
    }

    private void Wait()
    {
        SceneManager.LoadScene(sceneNavn);
    }
}
