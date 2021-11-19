using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MA.Events;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    [Header("Minigame Setup")]
    public string minigameName;
    public string beginText;
    public int timeToComplete;
    public int timeReward;
    [Space(15)]
    private Coroutine broadcast;
    [Header("Countdown Settings")]
    [Range(0,5)]
    public int countdownTime = 3;
    public bool overrideCountdown;
    public string[] overrideWords;
    [Space(15)]
    private bool gameStarted;
    [Header("Event System")]
    public UnityEvent startGame;
    public BoolEvent gameFinished;
    [HideInInspector]
    public FloatEvent globalTimeReward;
    [HideInInspector]
    public FloatEvent globalTime;
    [HideInInspector]
    public FloatEvent localTime;
    public StringEvent countdown;
    
    [Space(15)]
    private float localTimer;
    [Header("Canvas Setup")]
    public Canvas[] canvi;
    
    [HideInInspector]
    public int completedMinigames;
    
    private void Awake()
    {
        if (overrideCountdown)
        {
            countdownTime = overrideWords.Length;
        }


        if (!overrideCountdown)
        {
            if (completedMinigames > 5)
            {
                countdownTime = Mathf.Clamp(countdownTime--, 0, 100);
            }
            if (completedMinigames > 10)
            {
                countdownTime = Mathf.Clamp(countdownTime--, 0, 100);
            }
            if (completedMinigames > 15)
            {
                countdownTime = Mathf.Clamp(countdownTime--, 0, 100);
            }
            if (completedMinigames > 20)
            {
                countdownTime = Mathf.Clamp(countdownTime--, 0, 100);
            }
            if (completedMinigames > 25)
            {
                countdownTime = Mathf.Clamp(countdownTime--, 0, 100);
            }

            if (countdownTime != 0)
            {
                countdown.Raise(countdownTime.ToString());
            }
            
        }
        else
        {
            countdown.Raise(overrideWords[overrideWords.Length - countdownTime]);
            
        }

        StartCoroutine(StartSequence(countdownTime));
        foreach (Canvas canvas in canvi)
        {
            canvas.worldCamera = Camera.main;
        }
        localTimer = timeToComplete;
        localTime.Raise(timeToComplete);
    }

    private void Update()
    {
        if (gameStarted)
        {


            localTimer -= Time.deltaTime;
            localTime.Raise(localTimer);

            if (localTimer <= 0)
            {
                EndGame(3);
            }
        }
    }

    private IEnumerator StartSequence(int countdownLenght)
    {
        while (true)
        {
            if (countdownLenght > 0)
            {
                if (!overrideCountdown)
                {
                    countdown.Raise(countdownLenght.ToString());
                }
                else
                {
                    countdown.Raise(overrideWords[overrideWords.Length-countdownLenght]);
                }
                
            }
            if (countdownLenght == 0)
            {
                countdown.Raise(beginText);
                
                countdownLenght--;
                yield return new WaitForSeconds(0.5f);
                
            }
            if(countdownLenght < 0)
            {
                countdown.Raise(" ");
                StartGame();
                gameStarted = true;
                StopAllCoroutines();
            }
            countdownLenght--;
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void StartGame()
    {
        startGame.Invoke();
    }
    public void EndGame(int won)
    {
        broadcast = StartCoroutine(BroadcastEndGame(won,0));
        switch (won)
        {
            case 1:
                countdown.Raise("You Won");
                globalTimeReward.Raise(timeReward);
                Debug.Log("Added " + timeReward + " to global time");
                break;
            case 2:
                countdown.Raise("You Lost");
                globalTimeReward.Raise(-localTimer);
                break;
            case 3:
                countdown.Raise("Time Up");
                break;
            case 4:
                countdown.Raise("Tie");
                globalTimeReward.Raise(-localTimer);
                break;
        }
      
        
    }

    public IEnumerator BroadcastEndGame(int won, int loop)
    {
        while (true)
        {
            if(loop == 0)
            {
                loop++;
                yield return new WaitForSeconds(1);
            }
            if(won == 1)
            {
                gameFinished.Raise(true);
            }
            else
            {
                gameFinished.Raise(false);
            }
            
            if(broadcast != null)
            {
                StopCoroutine(broadcast);
            }
            StopAllCoroutines();
            yield return new WaitForEndOfFrame();
        }
    }
}
