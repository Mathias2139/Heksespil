using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text;
    
    public void UpdateCountdown(string recievedText)
    {
        
        
            text.text = recievedText;
       
        
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
