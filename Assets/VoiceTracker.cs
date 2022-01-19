using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTracker : MonoBehaviour
{
    public TimeSinceVoice timer;
    private void Update()
    {
        timer.time += Time.deltaTime;
    }
    public void Reset()
    {
        timer.time = 0;
    }
}
