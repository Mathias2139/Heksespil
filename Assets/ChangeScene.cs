using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MA.Events;

public class ChangeScene : MonoBehaviour
{
    public string scene;
    public FloatEvent musicEvent;
  public void SwitchScene()
    {
        musicEvent.Raise(0);
        SceneManager.LoadScene(scene);

    }
}
