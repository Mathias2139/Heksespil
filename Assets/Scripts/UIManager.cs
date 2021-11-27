using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text;
    public Text globalTimerText;
    public Slider localTimeSlider;
    public Image localTimerBar;
    public Gradient localTimerColors;

    private int lastGlobalTime;
    private int currentLocalTime;
    
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
        if(Mathf.RoundToInt(time + 0.5f) != lastGlobalTime)
        {
            globalTimerText.text = Mathf.RoundToInt(time + 0.5f).ToString();
            lastGlobalTime = Mathf.RoundToInt(time + 0.5f);
            

        }
        
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
