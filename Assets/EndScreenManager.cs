using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndScreenManager : MonoBehaviour
{
    public UnityEvent[] events;
    [Range(0,5)]
    public int[] timeBetweenEvents;

    private void Start()
    {
        StartCoroutine(InvokeEvents());
     
    }

    IEnumerator InvokeEvents()
    {
        while (true)
        {
            for (int i = 0; i < events.Length; i++)
            {
                events[i].Invoke();
                Debug.Log("Invoked Event");
               
                yield return new WaitForSeconds(timeBetweenEvents[i]);

            }
            StopAllCoroutines();
            yield return new WaitForEndOfFrame();
        }
    }
}
