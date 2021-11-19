using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text;
    public Text globalTimerText;
    public Text localTimerText;

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
        currentLocalTime = Mathf.Clamp(Mathf.RoundToInt(time-0.5f),0,1000);
    }
    public void UpdateGlobalTimer(float time)
    {
        if(Mathf.RoundToInt(time + 0.5f) != lastGlobalTime)
        {
            globalTimerText.text = Mathf.RoundToInt(time + 0.5f).ToString();
            lastGlobalTime = Mathf.RoundToInt(time + 0.5f);
            localTimerText.text = currentLocalTime.ToString();

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
