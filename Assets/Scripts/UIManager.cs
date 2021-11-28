using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text;
    public Text globalTimerText;
    public Slider[] globalTimerSliders;
    public Slider localTimeSlider;
    public Image localTimerBar;
    public Gradient localTimerColors;

    private bool timerStarted;
    private int lastGlobalTime;
    private int currentLocalTime;
    private float globalStartTime;
    
    public void UpdateCountdown(string recievedText)
    {
            text.gameObject.GetComponent<Animation>().Stop("Countdown_Growing");
            text.gameObject.GetComponent<Animation>().Play("Countdown_Growing");
            text.text = recievedText;
    }
    public void UpdateLocalTimer(float time)
    {
        localTimeSlider.value = time;
        localTimerBar.color = localTimerColors.Evaluate(time);
    }
    public void UpdateGlobalTimer(float time)
    {
        if (!timerStarted)
        {
            globalStartTime = time;
            timerStarted = true;
        }
        if(Mathf.RoundToInt(time + 0.5f) != lastGlobalTime)
        {
            globalTimerText.text = Mathf.RoundToInt(time + 0.5f).ToString();
            lastGlobalTime = Mathf.RoundToInt(time + 0.5f);
        }
        globalTimerSliders[0].value = time / globalStartTime;
        globalTimerSliders[1].value = (time / globalStartTime) * -1 + 1;
        
    }

    private IEnumerator ClearText(Text text, float delay)
    {
        while (true)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                text.text = "";
                StopAllCoroutines();
            }
        }
    }
}
